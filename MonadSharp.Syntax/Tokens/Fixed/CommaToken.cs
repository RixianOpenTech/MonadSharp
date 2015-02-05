using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed
{
    public sealed class CommaToken : SyntaxToken
    {
        public const string TokenName = "Comma";
        public const string Syntax = ",";

        public CommaToken()
            : base(Syntax)
        {
        }
    }
}
