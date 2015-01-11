using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords
{
    public sealed class WhileToken : KeywordToken
    {
        public const string TokenName = "While";
        public const string Syntax = "while";

        public WhileToken() 
            : base(Syntax)
        {
        }
    }
}
