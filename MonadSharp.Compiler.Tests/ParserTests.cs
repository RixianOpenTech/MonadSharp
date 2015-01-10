using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonadSharp.Compiler.Lexer;
using MonadSharp.Compiler.Parser;
using MonadSharp.Compiler.Tokens;
using MonadSharp.Compiler.Tokens.TokenFactories;

namespace MonadSharp.Compiler.Tests
{
    [TestClass]
    public class ParserTests
    {
        private string sampleProgramText;
        private string sampleProgramTextMini;

        [TestInitialize]
        public void LoadSampleProgram()
        {
            this.sampleProgramText = File.ReadAllText("SampleProgram.ms");
            this.sampleProgramTextMini = File.ReadAllText("SampleProgram-Mini.ms");
        }

        [TestMethod]
        public void TestMethod1()
        {
            var tokens = MonadSharpLexer.Parse(this.sampleProgramText);
            MonadSharpParser.Parse(tokens);
        }

        [TestMethod]
        public void ParseMini()
        {
            var tokens = MonadSharpLexer.Parse(this.sampleProgramText);
            var unknownTokens = tokens.OfType<UnknownToken>().ToList();
            var miniTokens = MonadSharpLexer.Parse(this.sampleProgramText);
            var miniUnknownTokens = miniTokens.OfType<UnknownToken>().ToList();
        }
    }
}
