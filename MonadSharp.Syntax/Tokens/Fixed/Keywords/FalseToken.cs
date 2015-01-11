using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords
{
    public sealed class FalseToken : BooleanTypeToken
    {
        public const string TokenName = "False";
        public const string Syntax = "false";

        public FalseToken() 
            : base(Syntax)
        {
        }
    }
}
