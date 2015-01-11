namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class ConstantBooleanTokenFactory : TokenFactory
    {
        internal ConstantBooleanTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new BooleanTypeToken(tokenValue);
        }

        public override string TokenName
        {
            get { return BooleanTypeToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"true|false"; }
        }
    }
}
