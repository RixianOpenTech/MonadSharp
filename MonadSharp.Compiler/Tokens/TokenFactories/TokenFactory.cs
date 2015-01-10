using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public abstract class TokenFactory
    {
        public static IReadOnlyDictionary<string, TokenFactory> TokenFactories { get; private set; }

        static TokenFactory()
        {
            var tokenFactoryType = typeof (TokenFactory);
            var currentAssembly = tokenFactoryType.GetTypeInfo().Assembly;
            var tokenFactoryTypeInfos = currentAssembly.DefinedTypes.Where(info => !info.IsAbstract && info.IsSubclassOf(tokenFactoryType));
            var tokenFactories = from info in tokenFactoryTypeInfos
                                 let predicate =  new Func<ConstructorInfo, bool>(constructorInfo => !constructorInfo.GetParameters().Any())
                                 let constructor = info.DeclaredConstructors.Single(predicate)
                                 select constructor.Invoke(null) as TokenFactory;
            TokenFactories = tokenFactories.ToDictionary(factory => factory.TokenName);
        }

        public static SyntaxToken CreateToken(string tokenValue)
        {
            var tokenFactory = GetTokenParserFactory(tokenValue);
            if (tokenFactory == null)
                return null;

            return tokenFactory.ParseToken(tokenValue);
        }

        public abstract SyntaxToken ParseToken(string tokenValue);

        protected TokenFactory()
        {
            
        }

        public abstract string TokenName { get; }

        public string TokenRegexExactPattern
        {
            get { return string.Format("^{0}$", TokenRegexPattern); }
        }

        public string TokenRegexWithPaddingPattern
        {
            get { return string.Format(@"^{0}\s+|\s+{0}$|\s+{0}\s+|^{0}$", TokenRegexPattern); }
        }

        public abstract string TokenRegexPattern { get; }

        public bool CanParseToken(string value)
        {
            return Regex.IsMatch(value, this.TokenRegexExactPattern);
        }

        public static TokenFactory GetTokenParserFactory(string tokenValue)
        {
            return TokenFactories.Values.SingleOrDefault(factory => factory.CanParseToken(tokenValue));
        }
    }
}
