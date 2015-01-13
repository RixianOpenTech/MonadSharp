using MonadSharp.Syntax.Tokens.Fixed;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class LeftCurlyBraceTokenFactory : TokenFactory
    {
        internal LeftCurlyBraceTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new LeftCurlyBraceToken();
        }

        public override string TokenName
        {
            get { return LeftCurlyBraceToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"{"; }
        }
    }
}
