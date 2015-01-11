using MonadSharp.Syntax.Tokens.Fixed.Keywords;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class WhileTokenFactory : TokenFactory
    {
        internal WhileTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new WhileToken(tokenValue);
        }

        public override string TokenName
        {
            get { return WhileToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"while"; }
        }
    }
}
