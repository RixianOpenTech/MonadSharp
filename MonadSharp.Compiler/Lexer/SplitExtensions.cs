using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MonadSharp.Compiler.Tokens;
using MonadSharp.Compiler.Tokens.TokenFactories;

namespace MonadSharp.Compiler.Parser
{
    public static class SplitExtensions
    {
        public static IEnumerable<Token> SplitIntoTokens(string text)
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

        private static IEnumerable<Token> Split(this IEnumerable<Token> tokens, string tokenName, bool matchWithPadding = false)
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

        private static IEnumerable<Token> SplitPeriod(this IEnumerable<Token> tokens)
        {
            return Split(tokens, PeriodToken.TokenName);
        }

        private static IEnumerable<Token> SplitSemicolon(this IEnumerable<Token> tokens)
        {
            return Split(tokens, SemicolonToken.TokenName);
        }

        private static IEnumerable<Token> SplitConstantString(this IEnumerable<Token> tokens)
        {
            return Split(tokens, ConstantStringToken.TokenName);
        }

        private static IEnumerable<Token> SplitConstantInt32(this IEnumerable<Token> tokens)
        {
            return Split(tokens, ConstantInt32Token.TokenName);
        }

        private static IEnumerable<Token> SplitConstantBoolean(this IEnumerable<Token> tokens)
        {
            return Split(tokens, ConstantBooleanToken.TokenName);
        }

        private static IEnumerable<Token> SplitLeftCurlyBrace(this IEnumerable<Token> tokens)
        {
            return Split(tokens, LeftCurlyBraceToken.TokenName);
        }

        private static IEnumerable<Token> SplitRightCurlyBrace(this IEnumerable<Token> tokens)
        {
            return Split(tokens, RightCurlyBraceToken.TokenName);
        }

        private static IEnumerable<Token> SplitLeftParen(this IEnumerable<Token> tokens)
        {
            return Split(tokens, LeftParenToken.TokenName);
        }

        private static IEnumerable<Token> SplitRightParen(this IEnumerable<Token> tokens)
        {
            return Split(tokens, RightParenToken.TokenName);
        }

        private static IEnumerable<Token> SplitEquals(this IEnumerable<Token> tokens)
        {
            return Split(tokens, EqualsToken.TokenName);
        }

        private static IEnumerable<Token> SplitPlus(this IEnumerable<Token> tokens)
        {
            return Split(tokens, PlusToken.TokenName);
        }

        private static IEnumerable<Token> SplitMinus(this IEnumerable<Token> tokens)
        {
            return Split(tokens, MinusToken.TokenName);
        }

        private static IEnumerable<Token> SplitLessThan(this IEnumerable<Token> tokens)
        {
            return Split(tokens, LessThanToken.TokenName);
        }

        private static IEnumerable<Token> SplitGreaterThan(this IEnumerable<Token> tokens)
        {
            return Split(tokens, GreaterThanToken.TokenName);
        }

        private static IEnumerable<Token> SplitAsterisk(this IEnumerable<Token> tokens)
        {
            return Split(tokens, AsteriskToken.TokenName);
        }

        private static IEnumerable<Token> SplitForwardSlash(this IEnumerable<Token> tokens)
        {
            return Split(tokens, ForwardSlashToken.TokenName);
        }

        private static IEnumerable<Token> SplitPercent(this IEnumerable<Token> tokens)
        {
            return Split(tokens, PercentToken.TokenName);
        }

        private static IEnumerable<Token> SplitBool(this IEnumerable<Token> tokens)
        {
            return Split(tokens, BooleanToken.TokenName, true);
        }

        private static IEnumerable<Token> SplitString(this IEnumerable<Token> tokens)
        {
            return Split(tokens, StringToken.TokenName, true);
        }

        private static IEnumerable<Token> SplitInt32(this IEnumerable<Token> tokens)
        {
            return Split(tokens, Int32Token.TokenName, true);
        }

        private static IEnumerable<Token> SplitUnit(this IEnumerable<Token> tokens)
        {
            return Split(tokens, UnitToken.TokenName, true);
        }

        private static IEnumerable<Token> SplitIf(this IEnumerable<Token> tokens)
        {
            return Split(tokens, IfToken.TokenName, true);
        }

        private static IEnumerable<Token> SplitElse(this IEnumerable<Token> tokens)
        {
            return Split(tokens, ElseToken.TokenName, true);
        }

        private static IEnumerable<Token> SplitWhile(this IEnumerable<Token> tokens)
        {
            return Split(tokens, WhileToken.TokenName, true);
        }

        private static IEnumerable<Token> SplitSerial(this IEnumerable<Token> tokens)
        {
            return Split(tokens, SerialToken.TokenName, true);
        }

        private static IEnumerable<Token> SplitParallel(this IEnumerable<Token> tokens)
        {
            return Split(tokens, ParallelToken.TokenName, true);
        }

        private static IEnumerable<Token> SplitName(this IEnumerable<Token> tokens)
        {
            return Split(tokens, NameToken.TokenName);
        }
    }
}
