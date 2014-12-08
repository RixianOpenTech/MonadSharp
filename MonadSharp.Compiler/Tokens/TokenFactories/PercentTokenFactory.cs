namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class PercentTokenFactory : TokenFactory
    {
        internal PercentTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new PercentToken(tokenValue);
        }

        public override string TokenName
        {
            get { return PercentToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"%"; }
        }
    }
}
