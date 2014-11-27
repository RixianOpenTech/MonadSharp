namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class MinusTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return MinusToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^-$"; }
        }
    }
}
