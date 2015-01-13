using System.Text.RegularExpressions;
using MonadSharp.Syntax.Tokens.Fixed;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class CommaTokenFactory : TokenFactory
    {
        internal CommaTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new CommaToken();
        }

        public override string TokenName
        {
            get { return CommaToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return Regex.Escape(CommaToken.Syntax); }
        }
    }
}
