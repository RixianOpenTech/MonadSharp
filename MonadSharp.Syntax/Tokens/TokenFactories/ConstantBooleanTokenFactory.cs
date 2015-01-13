using System.Runtime.CompilerServices;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class ConstantBooleanTokenFactory : TokenFactory
    {
        public const string RegexPattern = @"true|false";
        internal ConstantBooleanTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return BooleanTypeToken.ParseToken(tokenValue);
        }

        public override string TokenName
        {
            get { return "ConstantBool"; }
        }

        public override string TokenRegexPattern
        {
            get { return RegexPattern; }
        }
    }
}
