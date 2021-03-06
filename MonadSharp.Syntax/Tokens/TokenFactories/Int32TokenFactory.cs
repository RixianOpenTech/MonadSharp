﻿using MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class Int32TokenFactory : TokenFactory
    {
        internal Int32TokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new Int32Token();
        }

        public override string TokenName
        {
            get { return Int32Token.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"int"; }
        }
    }
}
