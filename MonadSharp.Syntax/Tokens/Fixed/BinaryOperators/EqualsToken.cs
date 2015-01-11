using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.BinaryOperators
{
    public sealed class EqualsToken : BinaryOperatorToken
    {
        public const string TokenName = "Equals";
        public const string Syntax = "=";

        public EqualsToken()
            : base(Syntax)
        {
        }
    }
}
