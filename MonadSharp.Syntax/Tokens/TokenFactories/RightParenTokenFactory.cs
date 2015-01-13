using MonadSharp.Syntax.Tokens.Fixed;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class RightParenTokenFactory : TokenFactory
    {
        internal RightParenTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new RightParenToken();
        }

        public override string TokenName
        {
            get { return RightParenToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"\)"; }
        }
    }
}
