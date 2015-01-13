using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class MinusTokenFactory : TokenFactory
    {
        internal MinusTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new MinusToken();
        }

        public override string TokenName
        {
            get { return MinusToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"-"; }
        }
    }
}
