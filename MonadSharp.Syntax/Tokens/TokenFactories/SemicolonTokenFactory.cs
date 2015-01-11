using MonadSharp.Syntax.Tokens.Fixed;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class SemicolonTokenFactory : TokenFactory
    {
        internal SemicolonTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new SemicolonToken(tokenValue);
        }

        public override string TokenName
        {
            get { return SemicolonToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @";"; }
        }
    }
}
