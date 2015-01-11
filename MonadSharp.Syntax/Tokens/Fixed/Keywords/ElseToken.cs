using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords
{
    public sealed class ElseToken : KeywordToken
    {
        public const string TokenName = "Else";
        public const string Syntax = "else";

        public ElseToken() 
            : base(Syntax)
        {
        }
    }
}
