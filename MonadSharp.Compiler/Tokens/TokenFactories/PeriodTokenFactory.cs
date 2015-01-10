namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class PeriodTokenFactory : TokenFactory
    {
        public override SyntaxToken ParseToken(string tokenValue)
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
