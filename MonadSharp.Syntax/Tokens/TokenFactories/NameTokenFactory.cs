namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class NameTokenFactory : TokenFactory
    {
        internal NameTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new NameToken(tokenValue);
        }

        public override string TokenName
        {
            get { return NameToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^[A-Za-z_][a-zA-Z0-9_]*"; }
        }
    }
}
