namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class ConstantInt32TokenFactory : TokenFactory
    {
        internal ConstantInt32TokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new ConstantInt32Token(tokenValue);
        }

        public override string TokenName
        {
            get { return ConstantInt32Token.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"\d+"; }
        }
    }
}
