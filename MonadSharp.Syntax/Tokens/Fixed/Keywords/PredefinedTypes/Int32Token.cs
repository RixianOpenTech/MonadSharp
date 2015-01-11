using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes
{
    public sealed class Int32Token : PredefinedTypeToken
    {
        public const string TokenName = "Int32";
        public const string Syntax = "int";

        public Int32Token() 
            : base(Syntax)
        {
        }
    }
}
