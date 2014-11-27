using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonadSharp.Compiler.Tokens.TokenFactories;

namespace MonadSharp.Compiler.Tests
{
    [TestClass]
    public class TokenRegexTests
    {
        #region AsteriskTokenFactory

        [TestMethod]
        public void AsteriskTokenFactory_Valid_CanParse()
        {
            var factory = new AsteriskTokenFactory();
            var canParse = factory.CanParseToken("*");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void AsteriskTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new AsteriskTokenFactory();
            var canParse = factory.CanParseToken("123junk321*");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void AsteriskTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new AsteriskTokenFactory();
            var canParse = factory.CanParseToken(" *");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void AsteriskTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new AsteriskTokenFactory();
            var canParse = factory.CanParseToken("*123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void AsteriskTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new AsteriskTokenFactory();
            var canParse = factory.CanParseToken("* ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region BooleanTokenFactory

        [TestMethod]
        public void BooleanTokenFactory_Valid_CanParse()
        {
            var factory = new BooleanTokenFactory();
            var canParse = factory.CanParseToken("bool");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void BooleanTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new BooleanTokenFactory();
            var canParse = factory.CanParseToken("123junk321bool");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void BooleanTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new BooleanTokenFactory();
            var canParse = factory.CanParseToken(" bool");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void BooleanTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new BooleanTokenFactory();
            var canParse = factory.CanParseToken("bool123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void BooleanTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new BooleanTokenFactory();
            var canParse = factory.CanParseToken("bool ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region ElseTokenFactory

        [TestMethod]
        public void ElseTokenFactory_Valid_CanParse()
        {
            var factory = new ElseTokenFactory();
            var canParse = factory.CanParseToken("else");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void ElseTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new ElseTokenFactory();
            var canParse = factory.CanParseToken("123junk321else");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ElseTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new ElseTokenFactory();
            var canParse = factory.CanParseToken(" else");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ElseTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new ElseTokenFactory();
            var canParse = factory.CanParseToken("else123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ElseTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new ElseTokenFactory();
            var canParse = factory.CanParseToken("else ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region ForwardSlashTokenFactory

        [TestMethod]
        public void ForwardSlashTokenFactory_Valid_CanParse()
        {
            var factory = new ForwardSlashTokenFactory();
            var canParse = factory.CanParseToken("/");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void ForwardSlashTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new ForwardSlashTokenFactory();
            var canParse = factory.CanParseToken("123junk321/");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ForwardSlashTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new ForwardSlashTokenFactory();
            var canParse = factory.CanParseToken(" /");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ForwardSlashTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new ForwardSlashTokenFactory();
            var canParse = factory.CanParseToken("/123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void ForwardSlashTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new ForwardSlashTokenFactory();
            var canParse = factory.CanParseToken("/ ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region IfTokenFactory

        [TestMethod]
        public void IfTokenFactory_Valid_CanParse()
        {
            var factory = new IfTokenFactory();
            var canParse = factory.CanParseToken("if");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void IfTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new IfTokenFactory();
            var canParse = factory.CanParseToken("123junk321if");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void IfTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new IfTokenFactory();
            var canParse = factory.CanParseToken(" if");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void IfTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new IfTokenFactory();
            var canParse = factory.CanParseToken("if123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void IfTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new IfTokenFactory();
            var canParse = factory.CanParseToken("if ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region Int32TokenFactory

        [TestMethod]
        public void Int32TokenFactory_Valid_CanParse()
        {
            var factory = new Int32TokenFactory();
            var canParse = factory.CanParseToken("int");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void Int32TokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new Int32TokenFactory();
            var canParse = factory.CanParseToken("123junk321int");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void Int32TokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new Int32TokenFactory();
            var canParse = factory.CanParseToken(" int");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void Int32TokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new Int32TokenFactory();
            var canParse = factory.CanParseToken("int123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void Int32TokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new Int32TokenFactory();
            var canParse = factory.CanParseToken("int ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region LeftCurlyBraceTokenFactory

        [TestMethod]
        public void LeftCurlyBraceTokenFactory_Valid_CanParse()
        {
            var factory = new LeftCurlyBraceTokenFactory();
            var canParse = factory.CanParseToken("{");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void LeftCurlyBraceTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new LeftCurlyBraceTokenFactory();
            var canParse = factory.CanParseToken("123junk321{");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void LeftCurlyBraceTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new LeftCurlyBraceTokenFactory();
            var canParse = factory.CanParseToken(" {");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void LeftCurlyBraceTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new LeftCurlyBraceTokenFactory();
            var canParse = factory.CanParseToken("{123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void LeftCurlyBraceTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new LeftCurlyBraceTokenFactory();
            var canParse = factory.CanParseToken("{ ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region MinusTokenFactory

        [TestMethod]
        public void MinusTokenFactory_Valid_CanParse()
        {
            var factory = new MinusTokenFactory();
            var canParse = factory.CanParseToken("-");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void MinusTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new MinusTokenFactory();
            var canParse = factory.CanParseToken("123junk321-");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void MinusTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new MinusTokenFactory();
            var canParse = factory.CanParseToken(" -");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void MinusTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new MinusTokenFactory();
            var canParse = factory.CanParseToken("-123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void MinusTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new MinusTokenFactory();
            var canParse = factory.CanParseToken("- ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region PercentTokenFactory

        [TestMethod]
        public void PercentTokenFactory_Valid_CanParse()
        {
            var factory = new PercentTokenFactory();
            var canParse = factory.CanParseToken("%");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void PercentTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new PercentTokenFactory();
            var canParse = factory.CanParseToken("123junk321%");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PercentTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new PercentTokenFactory();
            var canParse = factory.CanParseToken(" %");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PercentTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new PercentTokenFactory();
            var canParse = factory.CanParseToken("%123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PercentTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new PercentTokenFactory();
            var canParse = factory.CanParseToken("% ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region PeriodTokenFactory

        [TestMethod]
        public void PeriodTokenFactory_Valid_CanParse()
        {
            var factory = new PeriodTokenFactory();
            var canParse = factory.CanParseToken(".");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void PeriodTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new PeriodTokenFactory();
            var canParse = factory.CanParseToken("123junk321.");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PeriodTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new PeriodTokenFactory();
            var canParse = factory.CanParseToken(" .");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PeriodTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new PeriodTokenFactory();
            var canParse = factory.CanParseToken(".123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PeriodTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new PeriodTokenFactory();
            var canParse = factory.CanParseToken(". ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region PlusTokenFactory

        [TestMethod]
        public void PlusTokenFactory_Valid_CanParse()
        {
            var factory = new PlusTokenFactory();
            var canParse = factory.CanParseToken("+");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void PlusTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new PlusTokenFactory();
            var canParse = factory.CanParseToken("123junk321+");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PlusTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new PlusTokenFactory();
            var canParse = factory.CanParseToken(" +");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PlusTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new PlusTokenFactory();
            var canParse = factory.CanParseToken("+123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void PlusTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new PlusTokenFactory();
            var canParse = factory.CanParseToken("+ ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region RightCurlyBraceTokenFactory

        [TestMethod]
        public void RightCurlyBraceTokenFactory_Valid_CanParse()
        {
            var factory = new RightCurlyBraceTokenFactory();
            var canParse = factory.CanParseToken("}");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void RightCurlyBraceTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new RightCurlyBraceTokenFactory();
            var canParse = factory.CanParseToken("123junk321}");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void RightCurlyBraceTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new RightCurlyBraceTokenFactory();
            var canParse = factory.CanParseToken(" }");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void RightCurlyBraceTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new RightCurlyBraceTokenFactory();
            var canParse = factory.CanParseToken("}123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void RightCurlyBraceTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new RightCurlyBraceTokenFactory();
            var canParse = factory.CanParseToken("} ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region SemicolonTokenFactory

        [TestMethod]
        public void SemicolonTokenFactory_Valid_CanParse()
        {
            var factory = new SemicolonTokenFactory();
            var canParse = factory.CanParseToken(";");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void SemicolonTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new SemicolonTokenFactory();
            var canParse = factory.CanParseToken("123junk321;");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void SemicolonTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new SemicolonTokenFactory();
            var canParse = factory.CanParseToken(" ;");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void SemicolonTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new SemicolonTokenFactory();
            var canParse = factory.CanParseToken(";123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void SemicolonTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new SemicolonTokenFactory();
            var canParse = factory.CanParseToken("; ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region StringTokenFactory

        [TestMethod]
        public void StringTokenFactory_Valid_CanParse()
        {
            var factory = new StringTokenFactory();
            var canParse = factory.CanParseToken("string");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void StringTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new StringTokenFactory();
            var canParse = factory.CanParseToken("123junk321string");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void StringTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new StringTokenFactory();
            var canParse = factory.CanParseToken(" string");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void StringTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new StringTokenFactory();
            var canParse = factory.CanParseToken("string123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void StringTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new StringTokenFactory();
            var canParse = factory.CanParseToken("string ");
            Assert.IsFalse(canParse);
        }

        #endregion

        #region UnitTokenFactory

        [TestMethod]
        public void UnitTokenFactory_Valid_CanParse()
        {
            var factory = new UnitTokenFactory();
            var canParse = factory.CanParseToken("unit");
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void UnitTokenFactory_PrependedJunk_CannotParse()
        {
            var factory = new UnitTokenFactory();
            var canParse = factory.CanParseToken("123junk321unit");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void UnitTokenFactory_PrependedSpace_CannotParse()
        {
            var factory = new UnitTokenFactory();
            var canParse = factory.CanParseToken(" unit");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void UnitTokenFactory_AppendedJunk_CannotParse()
        {
            var factory = new UnitTokenFactory();
            var canParse = factory.CanParseToken("unit123junk321");
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void UnitTokenFactory_AppendedSpace_CannotParse()
        {
            var factory = new UnitTokenFactory();
            var canParse = factory.CanParseToken("unit ");
            Assert.IsFalse(canParse);
        }

        #endregion
    }
}
