﻿namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class EqualsTokenFactory : TokenFactory
    {
        internal EqualsTokenFactory()
        {
            
        }

        public override Token ParseToken(string tokenValue)
        {
            return new EqualsToken(tokenValue);
        }

        public override string TokenName
        {
            get { return EqualsToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"\="; } //Match asterisk with no leading or trailing characters
        }
    }
}