using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.BinaryOperators
{
    public sealed class PlusToken : BinaryOperatorToken
    {
        public const string TokenName = "Plus";
        public const string Syntax = "+";

        public PlusToken() 
            : base(Syntax)
        {
        }
    }
}
