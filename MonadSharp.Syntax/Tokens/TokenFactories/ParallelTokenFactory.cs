using MonadSharp.Syntax.Tokens.Fixed.Keywords;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class ParallelTokenFactory : TokenFactory
    {
        internal ParallelTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new ParallelToken(tokenValue);
        }

        public override string TokenName
        {
            get { return ParallelToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"parallel"; }
        }
    }
}
