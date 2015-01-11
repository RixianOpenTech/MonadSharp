using MonadSharp.Syntax.Tokens.Fixed;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class LeftParenTokenFactory : TokenFactory
    {
        internal LeftParenTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new LeftParenToken(tokenValue);
        }

        public override string TokenName
        {
            get { return LeftParenToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"\("; }
        }
    }
}
