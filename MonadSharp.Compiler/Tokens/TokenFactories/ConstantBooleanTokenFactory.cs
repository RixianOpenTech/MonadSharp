namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class ConstantBooleanTokenFactory : TokenFactory
    {
        internal ConstantBooleanTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new ConstantBooleanToken(tokenValue);
        }

        public override string TokenName
        {
            get { return ConstantBooleanToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"true|false"; }
        }
    }
}
