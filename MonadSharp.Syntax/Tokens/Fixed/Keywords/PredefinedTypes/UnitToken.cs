using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes
{
    public sealed class UnitToken : SyntaxToken, IPredefinedTypeToken
    {
        public const string TokenName = "Unit";
        public const string Syntax = "unit";

        public UnitToken() 
            : base(Syntax)
        {
        }
    }
}
