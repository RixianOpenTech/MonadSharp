using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class LessThanTokenFactory : TokenFactory
    {
        internal LessThanTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new LessThanToken();
        }

        public override string TokenName
        {
            get { return LessThanToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"<"; } //Match asterisk with no leading or trailing characters
        }
    }
}
