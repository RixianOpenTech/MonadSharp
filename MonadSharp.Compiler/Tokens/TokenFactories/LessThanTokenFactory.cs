namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class LessThanTokenFactory : TokenFactory
    {
        internal LessThanTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new LessThanToken(tokenValue);
        }

        public override string TokenName
        {
            get { return LessThanToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"<"; } //Match asterisk with no leading or trailing characters
        }
    }
}
