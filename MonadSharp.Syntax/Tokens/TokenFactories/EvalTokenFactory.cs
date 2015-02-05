using System.Text.RegularExpressions;
using MonadSharp.Syntax.Tokens.Fixed;
using MonadSharp.Syntax.Tokens.Fixed.Keywords;

namespace MonadSharp.Syntax.Tokens.TokenFactories
{
    public sealed class EvalTokenFactory : TokenFactory
    {
        internal EvalTokenFactory()
        {
            
        }

        public override SyntaxToken ParseToken(string tokenValue)
        {
            return new EvalToken();
        }

        public override string TokenName
        {
            get { return EvalToken.TokenName; }
        }

        public override string TokenRegexPattern
        {
            get { return Regex.Escape(EvalToken.Syntax); }
        }
    }
}
