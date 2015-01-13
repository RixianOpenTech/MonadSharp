using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class PlusTokenFactory : TokenFactory
    {
        internal PlusTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new PlusToken();
        }

        public override string TokenName
        {
            get { return PlusToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"\+"; }
        }
    }
}
