namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class ConstantStringTokenFactory : TokenFactory
    {
        internal ConstantStringTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new ConstantStringToken(tokenValue);
        }

        public override string TokenName
        {
            get { return ConstantStringToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return "\".*\""; }
        }
    }
}
