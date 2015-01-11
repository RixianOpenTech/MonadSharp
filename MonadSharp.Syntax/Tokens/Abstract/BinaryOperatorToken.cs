namespace MonadSharp.Syntax.Tokens.Abstract
{
    public abstract class BinaryOperatorToken : FixedSyntaxToken
    {
        protected BinaryOperatorToken(string tokenValue) 
            : base(tokenValue)
        {
        }
    }
}
