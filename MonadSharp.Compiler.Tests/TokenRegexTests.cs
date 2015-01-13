using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonadSharp.Syntax.Tokens;
using MonadSharp.Syntax.Tokens.Fixed;
using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;
using MonadSharp.Syntax.Tokens.Fixed.Keywords;
using MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes;
using MonadSharp.Syntax.Tokens.TokenFactories;

namespace MonadSharp.Compiler.Tests
{
    [TestClass]
    public class TokenRegexTests
    {

        [TestMethod]
        public void TokenFactoryInitialization_Valid_Success()
        {
            var factories = TokenFactory.TokenFactories;
            Assert.AreEqual(17, factories.Count);
        }

        #region AsteriskTokenFactory

        [TestMethod]
        public void AsteriskTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[AsteriskToken.TokenName];
            var canParse = factory.CanParseToken("*");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void AsteriskTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[AsteriskToken.TokenName];
            var canParse = factory.CanParseToken("123junk321*");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void AsteriskTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[AsteriskToken.TokenName];
            var canParse = factory.CanParseToken(" *");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void AsteriskTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[AsteriskToken.TokenName];
            var canParse = factory.CanParseToken("*123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void AsteriskTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[AsteriskToken.TokenName];
            var canParse = factory.CanParseToken("* ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region BooleanTokenFactory

        [TestMethod]
        public void BooleanTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[BooleanToken.TokenName];
            var canParse = factory.CanParseToken("bool");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void BooleanTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[BooleanToken.TokenName];
            var canParse = factory.CanParseToken("123junk321bool");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void BooleanTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[BooleanToken.TokenName];
            var canParse = factory.CanParseToken(" bool");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void BooleanTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[BooleanToken.TokenName];
            var canParse = factory.CanParseToken("bool123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void BooleanTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[BooleanToken.TokenName];
            var canParse = factory.CanParseToken("bool ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region ElseTokenFactory

        [TestMethod]
        public void ElseTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[ElseToken.TokenName];
            var canParse = factory.CanParseToken("else");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void ElseTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ElseToken.TokenName];
            var canParse = factory.CanParseToken("123junk321else");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ElseTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ElseToken.TokenName];
            var canParse = factory.CanParseToken(" else");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ElseTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ElseToken.TokenName];
            var canParse = factory.CanParseToken("else123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ElseTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ElseToken.TokenName];
            var canParse = factory.CanParseToken("else ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region ForwardSlashTokenFactory

        [TestMethod]
        public void ForwardSlashTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[ForwardSlashToken.TokenName];
            var canParse = factory.CanParseToken("/");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void ForwardSlashTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ForwardSlashToken.TokenName];
            var canParse = factory.CanParseToken("123junk321/");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ForwardSlashTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ForwardSlashToken.TokenName];
            var canParse = factory.CanParseToken(" /");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ForwardSlashTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ForwardSlashToken.TokenName];
            var canParse = factory.CanParseToken("/123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ForwardSlashTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ForwardSlashToken.TokenName];
            var canParse = factory.CanParseToken("/ ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region IfTokenFactory

        [TestMethod]
        public void IfTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[IfToken.TokenName];
            var canParse = factory.CanParseToken("if");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void IfTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[IfToken.TokenName];
            var canParse = factory.CanParseToken("123junk321if");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void IfTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[IfToken.TokenName];
            var canParse = factory.CanParseToken(" if");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void IfTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[IfToken.TokenName];
            var canParse = factory.CanParseToken("if123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void IfTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[IfToken.TokenName];
            var canParse = factory.CanParseToken("if ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region Int32TokenFactory

        [TestMethod]
        public void Int32TokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[Int32Token.TokenName];
            var canParse = factory.CanParseToken("int");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void Int32TokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[Int32Token.TokenName];
            var canParse = factory.CanParseToken("123junk321int");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void Int32TokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[Int32Token.TokenName];
            var canParse = factory.CanParseToken(" int");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void Int32TokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[Int32Token.TokenName];
            var canParse = factory.CanParseToken("int123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void Int32TokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[Int32Token.TokenName];
            var canParse = factory.CanParseToken("int ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region ConstantInt32TokenFactory

        [TestMethod]
        public void ConstantInt32TokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[ConstantInt32Token.TokenName];
            var canParse = factory.CanParseToken("123456");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void ConstantInt32TokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ConstantInt32Token.TokenName];
            var canParse = factory.CanParseToken("junkjunkjunk123456");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ConstantInt32TokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ConstantInt32Token.TokenName];
            var canParse = factory.CanParseToken(" 123456");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ConstantInt32TokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ConstantInt32Token.TokenName];
            var canParse = factory.CanParseToken("123456junkjunkjunk");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ConstantInt32TokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ConstantInt32Token.TokenName];
            var canParse = factory.CanParseToken("123456 ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region LeftCurlyBraceTokenFactory

        [TestMethod]
        public void LeftCurlyBraceTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[LeftCurlyBraceToken.TokenName];
            var canParse = factory.CanParseToken("{");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void LeftCurlyBraceTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[LeftCurlyBraceToken.TokenName];
            var canParse = factory.CanParseToken("123junk321{");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void LeftCurlyBraceTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[LeftCurlyBraceToken.TokenName];
            var canParse = factory.CanParseToken(" {");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void LeftCurlyBraceTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[LeftCurlyBraceToken.TokenName];
            var canParse = factory.CanParseToken("{123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void LeftCurlyBraceTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[LeftCurlyBraceToken.TokenName];
            var canParse = factory.CanParseToken("{ ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region MinusTokenFactory

        [TestMethod]
        public void MinusTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[MinusToken.TokenName];
            var canParse = factory.CanParseToken("-");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void MinusTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[MinusToken.TokenName];
            var canParse = factory.CanParseToken("123junk321-");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void MinusTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[MinusToken.TokenName];
            var canParse = factory.CanParseToken(" -");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void MinusTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[MinusToken.TokenName];
            var canParse = factory.CanParseToken("-123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void MinusTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[MinusToken.TokenName];
            var canParse = factory.CanParseToken("- ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region PercentTokenFactory

        [TestMethod]
        public void PercentTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[PercentToken.TokenName];
            var canParse = factory.CanParseToken("%");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void PercentTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PercentToken.TokenName];
            var canParse = factory.CanParseToken("123junk321%");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PercentTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PercentToken.TokenName];
            var canParse = factory.CanParseToken(" %");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PercentTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PercentToken.TokenName];
            var canParse = factory.CanParseToken("%123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PercentTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PercentToken.TokenName];
            var canParse = factory.CanParseToken("% ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region PeriodTokenFactory

        [TestMethod]
        public void PeriodTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[PeriodToken.TokenName];
            var canParse = factory.CanParseToken(".");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void PeriodTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PeriodToken.TokenName];
            var canParse = factory.CanParseToken("123junk321.");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PeriodTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PeriodToken.TokenName];
            var canParse = factory.CanParseToken(" .");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PeriodTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PeriodToken.TokenName];
            var canParse = factory.CanParseToken(".123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PeriodTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PeriodToken.TokenName];
            var canParse = factory.CanParseToken(". ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region PlusTokenFactory

        [TestMethod]
        public void PlusTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[PlusToken.TokenName];
            var canParse = factory.CanParseToken("+");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void PlusTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PlusToken.TokenName];
            var canParse = factory.CanParseToken("123junk321+");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PlusTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PlusToken.TokenName];
            var canParse = factory.CanParseToken(" +");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PlusTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PlusToken.TokenName];
            var canParse = factory.CanParseToken("+123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PlusTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[PlusToken.TokenName];
            var canParse = factory.CanParseToken("+ ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region RightCurlyBraceTokenFactory

        [TestMethod]
        public void RightCurlyBraceTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[RightCurlyBraceToken.TokenName];
            var canParse = factory.CanParseToken("}");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void RightCurlyBraceTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[RightCurlyBraceToken.TokenName];
            var canParse = factory.CanParseToken("123junk321}");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void RightCurlyBraceTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[RightCurlyBraceToken.TokenName];
            var canParse = factory.CanParseToken(" }");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void RightCurlyBraceTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[RightCurlyBraceToken.TokenName];
            var canParse = factory.CanParseToken("}123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void RightCurlyBraceTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[RightCurlyBraceToken.TokenName];
            var canParse = factory.CanParseToken("} ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region SemicolonTokenFactory

        [TestMethod]
        public void SemicolonTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[SemicolonToken.TokenName];
            var canParse = factory.CanParseToken(";");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void SemicolonTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[SemicolonToken.TokenName];
            var canParse = factory.CanParseToken("123junk321;");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void SemicolonTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[SemicolonToken.TokenName];
            var canParse = factory.CanParseToken(" ;");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void SemicolonTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[SemicolonToken.TokenName];
            var canParse = factory.CanParseToken(";123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void SemicolonTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[SemicolonToken.TokenName];
            var canParse = factory.CanParseToken("; ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region StringTokenFactory

        [TestMethod]
        public void StringTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[StringToken.TokenName];
            var canParse = factory.CanParseToken("string");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void StringTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[StringToken.TokenName];
            var canParse = factory.CanParseToken("123junk321string");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void StringTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[StringToken.TokenName];
            var canParse = factory.CanParseToken(" string");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void StringTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[StringToken.TokenName];
            var canParse = factory.CanParseToken("string123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void StringTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[StringToken.TokenName];
            var canParse = factory.CanParseToken("string ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region ConstantStringTokenFactory

        [TestMethod]
        public void ConstantStringTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[ConstantStringToken.TokenName];
            var canParse = factory.CanParseToken("\"1234foo bar = 1 + 2 * 3 \\ 4 (blah)\"");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void ConstantStringTokenFactory_MissingFirstQuote_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ConstantStringToken.TokenName];
            var canParse = factory.CanParseToken("1234foo bar = 1 + 2 * 3 \\ 4 (blah)\"");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ConstantStringTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ConstantStringToken.TokenName];
            var canParse = factory.CanParseToken(" \"1234foo bar = 1 + 2 * 3 \\ 4 (blah)\"");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ConstantStringTokenFactory_MissingSecondQuote_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ConstantStringToken.TokenName];
            var canParse = factory.CanParseToken("\"1234foo bar = 1 + 2 * 3 \\ 4 (blah)");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ConstantStringTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[ConstantStringToken.TokenName];
            var canParse = factory.CanParseToken("\"1234foo bar = 1 + 2 * 3 \\ 4 (blah)\" ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region UnitTokenFactory

        [TestMethod]
        public void UnitTokenFactory_Valid_CanParse()
        {
            var factory = TokenFactory.TokenFactories[UnitToken.TokenName];
            var canParse = factory.CanParseToken("unit");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void UnitTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[UnitToken.TokenName];
            var canParse = factory.CanParseToken("123junk321unit");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void UnitTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[UnitToken.TokenName];
            var canParse = factory.CanParseToken(" unit");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void UnitTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[UnitToken.TokenName];
            var canParse = factory.CanParseToken("unit123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void UnitTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = TokenFactory.TokenFactories[UnitToken.TokenName];
            var canParse = factory.CanParseToken("unit ");
            Assert.IsFalse(canParse);
        }

        #endregion
    }
}
