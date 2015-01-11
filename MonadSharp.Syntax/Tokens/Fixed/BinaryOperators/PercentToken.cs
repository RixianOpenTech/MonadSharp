using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.BinaryOperators
{
    public sealed class PercentToken : BinaryOperatorToken
    {
        public const string TokenName = "Percent";
        public const string Syntax = "%";

        public PercentToken() 
            : base(Syntax)
        {
        }
    }
}
