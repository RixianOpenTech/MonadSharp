namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class RightCurlyBraceTokenFactory : TokenFactory
    {
        internal RightCurlyBraceTokenFactory()
        {
            
        }

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
