namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class ConstantStringTokenFactory : TokenFactory
    {
        internal ConstantStringTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new ConstantStringToken(tokenValue);
        }

        public override string TokenName
        {
            get { return ConstantStringToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return "\".*\""; }
        }
    }
}
