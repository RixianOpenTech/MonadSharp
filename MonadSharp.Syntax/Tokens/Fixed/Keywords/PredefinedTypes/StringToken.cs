using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes
{
    public sealed class StringToken : SyntaxToken, IPredefinedTypeToken
    {
        public const string TokenName = "String";
        public const string Syntax = "string";

        public StringToken() 
            : base(Syntax)
        {
        }
    }
}
