using MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class StringTokenFactory : TokenFactory
    {
        internal StringTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new StringToken();
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
