namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class PeriodTokenFactory : TokenFactory
    {
        public override Token ParseToken(string tokenValue)
        {
            return new PeriodToken(tokenValue);
        }

        public override string TokenName
        {
            get { return PeriodToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"\."; }
        }
    }
}
