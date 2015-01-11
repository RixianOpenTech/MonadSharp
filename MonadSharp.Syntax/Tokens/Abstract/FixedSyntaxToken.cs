namespace MonadSharp.Syntax.Tokens.Abstract
{
    public abstract class FixedSyntaxToken : SyntaxToken
    {
        public string TokenValue { get; private set; }
        protected FixedSyntaxToken(string tokenValue) 
            : base(tokenValue)
        {
            this.TokenValue = tokenValue;
        }
    }
}