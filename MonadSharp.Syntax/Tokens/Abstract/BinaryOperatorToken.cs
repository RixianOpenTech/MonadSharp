namespace MonadSharp.Syntax.Tokens.Abstract
{
    public abstract class BinaryOperatorToken : SyntaxToken, IFixedSyntaxToken
    {
        protected BinaryOperatorToken(string tokenValue) 
            : base(tokenValue)
        {
        }
    }
}
