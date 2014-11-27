namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class PercentTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return PercentToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^%$"; }
        }
    }
}
