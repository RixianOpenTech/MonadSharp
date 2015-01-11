namespace MonadSharp.Syntax.Tokens
{
    public class ConstantInt32Token : SyntaxToken
    {
        public const string TokenName = "ConstantInt32";

        public ConstantInt32Token(string tokenValue) : base(tokenValue)
        {
        }
    }
}
