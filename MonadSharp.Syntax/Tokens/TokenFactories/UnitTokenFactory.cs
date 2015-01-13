using MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class UnitTokenFactory : TokenFactory
    {
        internal UnitTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new UnitToken();
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
