namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class ConstantInt32TokenFactory : TokenFactory
    {
        internal ConstantInt32TokenFactory()
        {
            
        }

        public override string TokenName
        {
            get { return ConstantInt32Token.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^\d+$"; }
        }
    }
}
