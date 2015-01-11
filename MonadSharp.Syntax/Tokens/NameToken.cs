namespace MonadSharp.Syntax.Tokens
{
    public class NameToken : SyntaxToken
    {
        public const string TokenName = "Name";

        public NameToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
