namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class ForwardSlashTokenFactory : TokenFactory
    {
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
