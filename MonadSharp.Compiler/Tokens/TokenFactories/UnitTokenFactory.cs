namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class UnitTokenFactory : TokenFactory
    {
        internal UnitTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new UnitToken(tokenValue);
        }

        public override string TokenName
        {
            get { return UnitToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"unit"; }
        }
    }
}
