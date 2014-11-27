namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class BooleanTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return BooleanToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^bool$"; }
        }
    }
}
