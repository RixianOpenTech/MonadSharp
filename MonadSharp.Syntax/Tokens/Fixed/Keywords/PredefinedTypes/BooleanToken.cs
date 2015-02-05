using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes
{
    public sealed class BooleanToken : SyntaxToken, IPredefinedTypeToken
    {
        public const string TokenName = "Boolean";
        public const string Syntax = "bool";

        public BooleanToken() 
            : base(Syntax)
        {
        }
    }
}
