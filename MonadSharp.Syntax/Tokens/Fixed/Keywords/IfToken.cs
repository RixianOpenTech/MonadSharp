using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords
{
    public sealed class IfToken : SyntaxToken, IKeywordToken
    {
        public const string TokenName = "If";
        public const string Syntax = "if";

        public IfToken() 
            : base(Syntax)
        {
        }
    }
}
