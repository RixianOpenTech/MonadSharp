using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.BinaryOperators
{
    public sealed class MinusToken : BinaryOperatorToken
    {
        public const string TokenName = "Minus";
        public const string Syntax = "-";

        public MinusToken() 
            : base(Syntax)
        {
        }
    }
}
