using System.Text.RegularExpressions;
using MonadSharp.Syntax.Tokens.Fixed;
using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;
using MonadSharp.Syntax.Tokens.Fixed.Keywords;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class RangeKeywordTokenFactory : TokenFactory
    {
        internal RangeKeywordTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new RangeKeywordToken();
        }

        public override string TokenName
        {
            get { return RangeKeywordToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return Regex.Escape(RangeKeywordToken.Syntax); }
        }
    }
}
