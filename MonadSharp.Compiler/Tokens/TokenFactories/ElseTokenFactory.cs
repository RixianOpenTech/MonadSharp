namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class ElseTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return ElseToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^else$"; }
        }
    }
}
