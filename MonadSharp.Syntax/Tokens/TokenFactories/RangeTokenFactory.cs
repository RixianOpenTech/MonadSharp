using System.Text.RegularExpressions;
using MonadSharp.Syntax.Tokens.Fixed;
using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class RangeTokenFactory : TokenFactory
    {
        internal RangeTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new RangeToken();
        }

        public override string TokenName
        {
            get { return RangeToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return Regex.Escape(RangeToken.Syntax); }
        }
    }
}
