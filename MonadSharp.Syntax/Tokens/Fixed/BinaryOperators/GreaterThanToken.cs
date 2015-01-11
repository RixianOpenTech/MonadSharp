using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.BinaryOperators
{
    public sealed class GreaterThanToken : BinaryOperatorToken
    {
        public const string TokenName = "GreaterThan";
        public const string Syntax = ">";

        public GreaterThanToken()
            : base(Syntax)
        {
        }
    }
}
