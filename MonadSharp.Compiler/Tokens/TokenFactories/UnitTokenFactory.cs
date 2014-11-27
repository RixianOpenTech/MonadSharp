namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class UnitTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return UnitToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^unit$"; }
        }
    }
}
