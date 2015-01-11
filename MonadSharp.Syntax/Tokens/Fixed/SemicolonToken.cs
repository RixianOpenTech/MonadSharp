namespace MonadSharp.Syntax.Tokens.Fixed
{
    public sealed class SemicolonToken : SyntaxToken
    {
        public const string TokenName = "Semicolon";
        public const string Syntax = ";";

        public SemicolonToken() 
            : base(Syntax)
        {
        }
    }
}
