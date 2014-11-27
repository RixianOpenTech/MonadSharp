namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class PeriodTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return PercentToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^\.$"; }
        }
    }
}
