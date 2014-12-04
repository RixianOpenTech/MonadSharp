namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class RightParenTokenFactory : TokenFactory
    {
        internal RightParenTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new RightParenToken(tokenValue);
        }

        public override string TokenName
        {
            get { return RightParenToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"\)"; }
        }
    }
}
