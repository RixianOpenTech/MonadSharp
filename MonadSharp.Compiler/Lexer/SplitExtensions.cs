using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MonadSharp.Syntax;
using MonadSharp.Syntax.Tokens;
using MonadSharp.Syntax.Tokens.Fixed;
using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;
using MonadSharp.Syntax.Tokens.Fixed.Keywords;
using MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes;
using MonadSharp.Syntax.Tokens.TokenFactories;

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
                .SplitEval()
                .SplitConstantBoolean()
                .SplitName()
                .SplitConstantInt32()
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
            return Split(tokens, PeriodToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitSemicolon(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, SemicolonToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitConstantString(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, ConstantStringToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitConstantInt32(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, ConstantInt32Token.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitConstantBoolean(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, BooleanTypeToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitLeftCurlyBrace(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, LeftCurlyBraceToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitRightCurlyBrace(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, RightCurlyBraceToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitLeftParen(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, LeftParenToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitRightParen(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, RightParenToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitEquals(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, EqualsToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitPlus(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, PlusToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitMinus(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, MinusToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitLessThan(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, LessThanToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitGreaterThan(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, GreaterThanToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitAsterisk(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, AsteriskToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitForwardSlash(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, ForwardSlashToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitPercent(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, PercentToken.TokenName).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitBool(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, BooleanToken.TokenName, true).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitString(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, StringToken.TokenName, true).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitInt32(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, Int32Token.TokenName, true).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitUnit(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, UnitToken.TokenName, true).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitIf(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, IfToken.TokenName, true).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitElse(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, ElseToken.TokenName, true).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitWhile(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, WhileToken.TokenName, true).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitSerial(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, SerialToken.TokenName, true).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitParallel(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, ParallelToken.TokenName, true).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitEval(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, EvalToken.TokenName, true).ToList();
        }

        private static IEnumerable<SyntaxToken> SplitName(this IEnumerable<SyntaxToken> tokens)
        {
            return Split(tokens, NameToken.TokenName).ToList();
        }
    }
}
