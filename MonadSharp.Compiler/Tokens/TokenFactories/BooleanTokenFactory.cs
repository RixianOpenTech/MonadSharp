namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class BooleanTokenFactory : TokenFactory
    {
        internal BooleanTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new BooleanToken(tokenValue);
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
