using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class PercentTokenFactory : TokenFactory
    {
        internal PercentTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new PercentToken();
        }

        public override string TokenName
        {
            get { return PercentToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"%"; }
        }
    }
}
