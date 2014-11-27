namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class IfTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return IfToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^if$"; }
        }
    }
}
