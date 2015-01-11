using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Tokens.Fixed
{
    public sealed class CommaToken : PredefinedTypeToken
    {
        public const string TokenName = "Comma";
        public const string Syntax = ",";

        public CommaToken()
            : base(Syntax)
        {
        }
    }
}
