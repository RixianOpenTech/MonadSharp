namespace MonadSharp.Syntax.Tokens.Fixed
{
    public sealed class LeftCurlyBraceToken : SyntaxToken
    {
        public const string TokenName = "LeftCurlyBrace";
        public const string Syntax = "{";

        public LeftCurlyBraceToken() 
            : base(Syntax)
        {
        }
    }
}
