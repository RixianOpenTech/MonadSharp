namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class GreaterThanTokenFactory : TokenFactory
    {
        internal GreaterThanTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new GreaterThanToken(tokenValue);
        }

        public override string TokenName
        {
            get { return GreaterThanToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"<"; } //Match asterisk with no leading or trailing characters
        }
    }
}
