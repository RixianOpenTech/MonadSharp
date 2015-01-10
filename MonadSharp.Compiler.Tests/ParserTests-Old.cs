using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using MonadSharp.Compiler.Parser;
using MonadSharp.Compiler.Lexer;

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
    }
}
