using MonadSharp.Syntax.Tokens.Fixed.Keywords;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class IfTokenFactory : TokenFactory
    {
        internal IfTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new IfToken(tokenValue);
        }

        public override string TokenName
        {
            get { return IfToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"if"; }
        }
    }
}
