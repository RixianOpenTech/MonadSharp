﻿using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class AsteriskTokenFactory : TokenFactory
    {
        internal AsteriskTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new AsteriskToken(tokenValue);
        }

        public override string TokenName
        {
            get { return AsteriskToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return @"\*"; } //Match asterisk with no leading or trailing characters
        }
    }
}