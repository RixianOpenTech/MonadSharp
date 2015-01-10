namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class ForwardSlashTokenFactory : TokenFactory
    {
        internal ForwardSlashTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new ForwardSlashToken(tokenValue);
        }

        public override string TokenName
        {
            get { return ForwardSlashToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"/"; }
        }
    }
}
