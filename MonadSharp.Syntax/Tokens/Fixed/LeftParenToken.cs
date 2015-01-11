namespace MonadSharp.Syntax.Tokens.Fixed
{
    public sealed class LeftParenToken : SyntaxToken
    {
        public const string TokenName = "LeftParen";
        public const string Syntax = "(";

        public LeftParenToken() 
            : base(Syntax)
        {
        }
    }
}
