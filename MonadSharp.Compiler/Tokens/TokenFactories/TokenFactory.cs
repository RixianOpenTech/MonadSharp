using System.Text.RegularExpressions;

namespace MonadSharp.Compiler.Tokens.TokenFactories
{
    public abstract class TokenFactory
    {
        public abstract string TokenName { get; }
        public abstract string TokenRegexPattern { get; }

        public bool CanParseToken(string value)
        {
            return Regex.IsMatch(value, this.TokenRegexPattern);
        }
    }
}
