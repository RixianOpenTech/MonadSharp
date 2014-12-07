namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class SerialTokenFactory : TokenFactory
    {
        internal SerialTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new SerialToken(tokenValue);
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
