using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords
{
    public sealed class ParallelToken : KeywordToken
    {
        public const string TokenName = "Parallel";
        public const string Syntax = "parallel";

        public ParallelToken() 
            : base(Syntax)
        {
        }
    }
}
