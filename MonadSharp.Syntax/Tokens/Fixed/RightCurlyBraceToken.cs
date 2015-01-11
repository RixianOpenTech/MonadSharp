namespace MonadSharp.Syntax.Tokens.Fixed
{
    public sealed class RightCurlyBraceToken : SyntaxToken
    {
        public const string TokenName = "RightCurlyBrace";
        public const string Syntax = "}";

        public RightCurlyBraceToken() 
            : base(Syntax)
        {
        }
    }
}
