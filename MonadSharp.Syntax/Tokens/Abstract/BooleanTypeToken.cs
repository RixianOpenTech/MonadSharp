using System;
using MonadSharp.Syntax.Tokens.Abstract;
using MonadSharp.Syntax.Tokens.Fixed.Keywords;

namespace MonadSharp.Syntax.Tokens
{
    public abstract class BooleanTypeToken : KeywordToken
    {
        public BooleanTypeToken(string tokenValue) : base(tokenValue)
        {
        }

        public static BooleanTypeToken ParseToken(string tokenValue)
        {
            if (TrueTypeToken.Syntax == tokenValue)
                return new TrueTypeToken();
            if (FalseToken.Syntax == tokenValue)
                return new FalseToken();
            throw new ArithmeticException();
        }
    }
}
