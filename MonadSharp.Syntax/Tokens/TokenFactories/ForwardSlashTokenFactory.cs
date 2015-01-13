using System.Text.RegularExpressions;
using MonadSharp.Syntax.Tokens.Fixed;
using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class ForwardSlashTokenFactory : TokenFactory
    {
        internal ForwardSlashTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new ForwardSlashToken();
        }

        public override string TokenName
        {
            get { return ForwardSlashToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return Regex.Escape(ForwardSlashToken.Syntax); }
        }
    }
}
