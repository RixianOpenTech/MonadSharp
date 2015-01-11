using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens
{
    public abstract class BooleanTypeToken : KeywordToken
    {
        public BooleanTypeToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
