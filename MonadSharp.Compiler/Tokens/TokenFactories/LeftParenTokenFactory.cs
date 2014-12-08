namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class LeftParenTokenFactory : TokenFactory
    {
        internal LeftParenTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new LeftParenToken(tokenValue);
        }

        public override string TokenName
        {
            get { return LeftParenToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"\("; }
        }
    }
}
