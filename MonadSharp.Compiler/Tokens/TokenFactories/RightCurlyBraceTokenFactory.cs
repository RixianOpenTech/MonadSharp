namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class RightCurlyBraceTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return RightCurlyBraceToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^}$"; }
        }
    }
}
