namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class SemicolonTokenFactory : TokenFactory
    {
        internal SemicolonTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new SemicolonToken(tokenValue);
        }

        public override string TokenName
        {
            get { return SemicolonToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @";"; }
        }
    }
}
