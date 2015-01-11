using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.BinaryOperators
{
    public sealed class LessThanToken : BinaryOperatorToken
    {
        public const string TokenName = "LessThan";
        public const string Syntax = "<";

        public LessThanToken()
            : base(Syntax)
        {
        }
    }
}
