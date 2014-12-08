namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class WhileTokenFactory : TokenFactory
    {
        internal WhileTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new WhileToken(tokenValue);
        }

        public override string TokenName
        {
            get { return WhileToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"while"; }
        }
    }
}
