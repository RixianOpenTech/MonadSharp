using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.BinaryOperators
{
    public sealed class AsteriskToken : BinaryOperatorToken
    {
        public const string TokenName = "Asterisk";
        public const string Syntax = "*";

        public AsteriskToken() 
            : base(Syntax)
        {
        }
    }
}
