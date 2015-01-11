namespace MonadSharp.Syntax.Tokens.Abstract
{
    public abstract class PredefinedTypeToken : KeywordToken
    {
        protected PredefinedTypeToken(string tokenValue)
            : base(tokenValue)
        {
        }
    }
}