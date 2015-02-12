using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords
{
    public sealed class RangeKeywordToken : SyntaxToken, IKeywordToken
    {
        public const string TokenName = "RangeKeyword";
        public const string Syntax = "range";

        public RangeKeywordToken() 
            : base(Syntax)
        {
        }
    }
}
