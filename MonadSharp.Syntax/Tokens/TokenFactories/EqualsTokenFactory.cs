﻿using System.Text.RegularExpressions;
using MonadSharp.Syntax.Tokens.Fixed;
using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class EqualsTokenFactory : TokenFactory
    {
        internal EqualsTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new EqualsToken();
        }

        public override string TokenName
        {
            get { return EqualsToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return Regex.Escape(EqualsToken.Syntax); }
        }
    }
}
