using MonadSharp.Syntax.Tokens.Fixed;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class RightCurlyBraceTokenFactory : TokenFactory
    {
        internal RightCurlyBraceTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new RightCurlyBraceToken(tokenValue);
        }

        public override string TokenName
        {
            get { return RightCurlyBraceToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"}"; }
        }
    }
}
