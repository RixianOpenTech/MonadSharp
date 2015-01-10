namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class StringTokenFactory : TokenFactory
    {
        internal StringTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new StringToken(tokenValue);
        }

        public override string TokenName
        {
            get { return StringToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"string"; }
        }
    }
}
