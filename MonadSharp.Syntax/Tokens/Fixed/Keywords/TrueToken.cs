using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords
{
    public sealed class TrueTypeToken : BooleanTypeToken
    {
        public const string TokenName = "True";
        public const string Syntax = "true";

        public TrueTypeToken() 
            : base(Syntax)
        {
        }
    }
}
