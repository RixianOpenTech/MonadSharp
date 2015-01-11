namespace MonadSharp.Syntax.Tokens
{
    public class UnknownToken : SyntaxToken
    {
        public const string TokenName = "Unknown";

        public UnknownToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
