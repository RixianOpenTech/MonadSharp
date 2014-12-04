namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class MinusTokenFactory : TokenFactory
    {
        internal MinusTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new MinusToken(tokenValue);
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
