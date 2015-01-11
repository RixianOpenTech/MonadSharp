namespace MonadSharp.Syntax.Tokens
{
    public class ConstantStringToken : SyntaxToken
    {
        public const string TokenName = "ConstantString";

        public ConstantStringToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
