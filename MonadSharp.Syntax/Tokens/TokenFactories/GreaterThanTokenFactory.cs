using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class GreaterThanTokenFactory : TokenFactory
    {
        internal GreaterThanTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new GreaterThanToken(tokenValue);
        }

        public override string TokenName
        {
            get { return GreaterThanToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"<"; } //Match asterisk with no leading or trailing characters
        }
    }
}
