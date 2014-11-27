namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class BooleanTokenFactory : TokenFactory
    {
        internal BooleanTokenFactory()
        {
            
        }

        public override string TokenName
        {
            get { return BooleanToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^bool$"; }
        }
    }
}
