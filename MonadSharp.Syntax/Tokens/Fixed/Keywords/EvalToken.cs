using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords
{
    public sealed class EvalToken : SyntaxToken, IKeywordToken
    {
        public const string TokenName = "Eval";
        public const string Syntax = "eval";

        public EvalToken() 
            : base(Syntax)
        {
        }
    }
}
