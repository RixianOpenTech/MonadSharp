namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class IfTokenFactory : TokenFactory
    {
        internal IfTokenFactory()
        {
            
        }

        public override string TokenName
        {
            get { return IfToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^if$"; }
        }
    }
}
