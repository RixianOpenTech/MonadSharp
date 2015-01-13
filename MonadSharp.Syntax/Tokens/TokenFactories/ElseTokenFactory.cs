using System.Text.RegularExpressions;
using MonadSharp.Syntax.Tokens.Fixed;
using MonadSharp.Syntax.Tokens.Fixed.Keywords;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class ElseTokenFactory : TokenFactory
    {
        internal ElseTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new ElseToken();
        }

        public override string TokenName
        {
            get { return ElseToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return Regex.Escape(ElseToken.Syntax); }
        }
    }
}
