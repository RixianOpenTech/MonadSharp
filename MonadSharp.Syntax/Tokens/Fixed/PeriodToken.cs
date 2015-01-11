namespace MonadSharp.Syntax.Tokens.Fixed
{
    public sealed class PeriodToken : SyntaxToken
    {
        public const string TokenName = "Period";
        public const string Syntax = ".";

        public PeriodToken() 
            : base(Syntax)
        {
        }
    }
}
