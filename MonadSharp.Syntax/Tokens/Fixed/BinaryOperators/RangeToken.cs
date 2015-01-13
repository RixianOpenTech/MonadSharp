using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.BinaryOperators
{
    public sealed class RangeToken : BinaryOperatorToken
    {
        public const string TokenName = "Range";
        public const string Syntax = "..";

        public RangeToken() 
            : base(Syntax)
        {
        }
    }
}
