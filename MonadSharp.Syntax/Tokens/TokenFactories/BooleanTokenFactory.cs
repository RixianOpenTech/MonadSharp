using MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class BooleanTokenFactory : TokenFactory
    {
        internal BooleanTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new BooleanToken();
        }

        public override string TokenName
        {
            get { return BooleanToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"bool"; }
        }
    }
}
