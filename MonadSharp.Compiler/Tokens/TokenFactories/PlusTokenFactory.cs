namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class PlusTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return PlusToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^\+$"; }
        }
    }
}
