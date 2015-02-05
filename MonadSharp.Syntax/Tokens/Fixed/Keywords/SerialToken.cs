using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed.Keywords
{
    public sealed class SerialToken : SyntaxToken, IKeywordToken
    {
        public const string TokenName = "Serial";
        public const string Syntax = "serial";

        public SerialToken() 
            : base(Syntax)
        {
        }
    }
}
