namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class CommaTokenFactory : TokenFactory
    {
        internal CommaTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new CommaToken(tokenValue);
        }

        public override string TokenName
        {
            get { return CommaToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @","; }
        }
    }
}
