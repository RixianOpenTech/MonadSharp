namespace MonadSharp.Syntax.Tokens.Fixed
{
    public sealed class RightParenToken : SyntaxToken
    {
        public const string TokenName = "RightParen";
        public const string Syntax = ")";

        public RightParenToken()
            : base(Syntax)
        {
        }
    }
}
