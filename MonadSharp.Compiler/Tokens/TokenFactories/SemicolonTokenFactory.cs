namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class SemicolonTokenFactory : TokenFactory
    {
        internal SemicolonTokenFactory()
        {
            
        }

        public override string TokenName
        {
            get { return SemicolonToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^;$"; }
        }
    }
}
