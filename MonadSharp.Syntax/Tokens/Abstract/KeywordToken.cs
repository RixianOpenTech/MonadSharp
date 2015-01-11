namespace MonadSharp.Syntax.Tokens.Abstract
{
    public abstract class KeywordToken : FixedSyntaxToken
    {
        protected KeywordToken(string tokenValue)
            : base(tokenValue)
        {
        }
    }
}