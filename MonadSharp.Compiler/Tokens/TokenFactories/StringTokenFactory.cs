namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class StringTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return StringToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^string$"; }
        }
    }
}
