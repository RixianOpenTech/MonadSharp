namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class SemicolonTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return SemicolonToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^;$"; }
        }
    }
}
