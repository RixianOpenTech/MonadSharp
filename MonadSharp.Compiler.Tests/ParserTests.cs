using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonadSharp.Compiler.Parser;
using MonadSharp.Compiler.Tokens;
using MonadSharp.Compiler.Tokens.TokenFactories;

namespace MonadSharp.Compiler.Tests
{
    [TestClass]
    public class ParserTests
    {
        private string sampleProgramText;

        [TestInitialize]
        public void LoadSampleProgram()
        {
            this.sampleProgramText = File.ReadAllText("SampleProgram.ms");
        }

        [TestMethod]
        public void TestMethod1()
        {
            var tokens = MonadSharpParser.Parse(this.sampleProgramText);
            var unknownTokens = tokens.OfType<UnknownToken>().ToList();
        }
    }
}
