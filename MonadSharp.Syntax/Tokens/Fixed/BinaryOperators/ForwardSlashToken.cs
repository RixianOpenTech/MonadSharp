using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.BinaryOperators
{
    public sealed class ForwardSlashToken : BinaryOperatorToken
    {
        public const string TokenName = "ForwardSlash";
        public const string Syntax = "/";

        public ForwardSlashToken() 
            : base(Syntax)
        {
        }
    }
}
