namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class Int32TokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return Int32Token.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^int$"; }
        }
    }
}
