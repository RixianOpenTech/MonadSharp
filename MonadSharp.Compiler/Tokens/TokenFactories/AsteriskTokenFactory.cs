namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public class AsteriskTokenFactory : TokenFactory
    {
        public override string TokenName
        {
            get { return AsteriskToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^\*$"; } //Match asterisk with no leading or trailing characters
        }
    }
}
