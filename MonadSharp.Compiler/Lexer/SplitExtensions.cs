using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MonadSharp.Compiler.Tokens;
using MonadSharp.Compiler.Tokens.TokenFactories;

namespace MonadSharp.Compiler.Parser
{
    public static class SplitExtensions
    {
        public static IEnumerable<SyntaxToken> SplitIntoTokens(string text)
        {
            var initialTokens = new[] {new UnknownToken(text)};
            return initialTokens
                .SplitConstantString()
                .SplitPeriod()
                .SplitSemicolon()
                .SplitLeftCurlyBrace()
                .SplitRightCurlyBrace()
                .SplitLeftParen()
                .SplitRightParen()
                .SplitEquals()
                .SplitPlus()
                .SplitPercent()
                .SplitForwardSlash()
                .SplitAsterisk()
                .SplitMinus()
                .SplitLessThan()
                .SplitGreaterThan()
                .SplitString()
                .SplitInt32()
                .SplitBool()
                .SplitUnit()
                .SplitIf()
                .SplitElse()
                .SplitWhile()
                .SplitSerial()
                .SplitParallel()
                .SplitConstantInt32()
                .SplitConstantBoolean()
                .SplitName()
                .Where(t => !string.IsNullOrWhiteSpace(t.TokenValue));
        }

        private static IEnumerable<SyntaxToken> Split(this IEnumerable<SyntaxToken> tokens, string tokenName, bool matchWithPadding = false)
        {
            var tokenFactory = TokenFactory.TokenFactories[tokenName];
            var regexPattern = matchWithPadding ? tokenFactory.TokenRegexWithPaddingPattern : tokenFactory.TokenRegexPattern;
            foreach (var token in tokens)
            {
                if (!(token is UnknownToken))
                {
                    yield return token;
                    continue;
                }

                var unknownToken = (UnknownToken)token;
                var splitValues = Regex.Split(unknownToken.TokenValue.Trim(), regexPattern);
                yield return new UnknownToken(splitValues[0]);
                var matches = Regex.Matches(unknownToken.TokenValue, regexPattern);

                for (int i = 0; i < matches.Count; i++)
                {
                    yield return tokenFactory.ParseToken(matches[i].Value);
                    yield return new UnknownToken(splitValues[i + 1]);
                }
            }
        }

        private static IEnumerable<SyntaxToken> SplitPeriod(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, PeriodToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitSemicolon(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, SemicolonToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitConstantString(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, ConstantStringToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitConstantInt32(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, ConstantInt32Token.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitConstantBoolean(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, ConstantBooleanToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitLeftCurlyBrace(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, LeftCurlyBraceToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitRightCurlyBrace(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, RightCurlyBraceToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitLeftParen(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, LeftParenToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitRightParen(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, RightParenToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitEquals(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, EqualsToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitPlus(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, PlusToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitMinus(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, MinusToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitLessThan(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, LessThanToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitGreaterThan(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, GreaterThanToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitAsterisk(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, AsteriskToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitForwardSlash(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, ForwardSlashToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitPercent(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, PercentToken.TokenName);
        }

        private static IEnumerable<SyntaxToken> SplitBool(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, BooleanToken.TokenName, true);
        }

        private static IEnumerable<SyntaxToken> SplitString(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, StringToken.TokenName, true);
        }

        private static IEnumerable<SyntaxToken> SplitInt32(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, Int32Token.TokenName, true);
        }

        private static IEnumerable<SyntaxToken> SplitUnit(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, UnitToken.TokenName, true);
        }

        private static IEnumerable<SyntaxToken> SplitIf(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, IfToken.TokenName, true);
        }

        private static IEnumerable<SyntaxToken> SplitElse(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, ElseToken.TokenName, true);
        }

        private static IEnumerable<SyntaxToken> SplitWhile(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, WhileToken.TokenName, true);
        }

        private static IEnumerable<SyntaxToken> SplitSerial(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, SerialToken.TokenName, true);
        }

        private static IEnumerable<SyntaxToken> SplitParallel(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, ParallelToken.TokenName, true);
        }

        private static IEnumerable<SyntaxToken> SplitName(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, NameToken.TokenName);
        }
    }
}
