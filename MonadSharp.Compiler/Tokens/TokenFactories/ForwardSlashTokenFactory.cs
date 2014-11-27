namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class ForwardSlashTokenFactory : TokenFactory
    {
        internal ForwardSlashTokenFactory()
        {
            
        }

        public override string TokenName
        {
            get { return ForwardSlashToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^/$"; }
        }
    }
}
