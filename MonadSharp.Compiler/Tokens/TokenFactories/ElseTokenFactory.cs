namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class ElseTokenFactory : TokenFactory
    {
        internal ElseTokenFactory()
        {
            
        }

        public override string TokenName
        {
            get { return ElseToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^else$"; }
        }
    }
}
