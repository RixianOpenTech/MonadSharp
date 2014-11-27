﻿namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public sealed class LeftCurlyBraceTokenFactory : TokenFactory
    {
        internal LeftCurlyBraceTokenFactory()
        {
            
        }

        public override string TokenName
        {
            get { return LeftCurlyBraceToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"^{$"; }
        }
    }
}
