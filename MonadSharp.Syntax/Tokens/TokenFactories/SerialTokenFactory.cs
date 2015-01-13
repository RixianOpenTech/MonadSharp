using MonadSharp.Syntax.Tokens.Fixed.Keywords;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class SerialTokenFactory : TokenFactory
    {
        internal SerialTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new SerialToken();
        }

        public override string TokenName
        {
            get { return SerialToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"serial"; }
        }
    }
}
