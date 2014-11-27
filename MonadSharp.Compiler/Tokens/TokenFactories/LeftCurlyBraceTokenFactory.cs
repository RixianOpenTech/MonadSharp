namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class LeftCurlyBraceTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return LeftCurlyBraceToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^{$"; }
        }
    }
}
