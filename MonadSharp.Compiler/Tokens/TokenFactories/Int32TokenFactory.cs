namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class Int32TokenFactory : TokenFactory
    {
        internal Int32TokenFactory()
        {
            
        }

        public override string TokenName
        {
            get { return Int32Token.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^int$"; }
        }
    }
}
