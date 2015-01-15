using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords
{
    public sealed class EvalToken : KeywordToken
    {
        public const string TokenName = "Eval";
        public const string Syntax = "eval";

        public EvalToken() 
            : base(Syntax)
        {
        }
    }
}
