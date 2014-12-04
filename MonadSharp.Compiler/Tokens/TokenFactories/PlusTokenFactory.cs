namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class PlusTokenFactory : TokenFactory
    {
        internal PlusTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new PlusToken(tokenValue);
        }

        public override string TokenName
        {
            get { return PlusToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"\+"; }
        }
    }
}
