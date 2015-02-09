using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonadSharp.Compiler.Emitter;
using MonadSharp.Compiler.Lexer;
using MonadSharp.Compiler.Parser;

namespace MonadSharp.Compiler.Tests
{
    [TestClass]
    public class EmitterTests
    {

        [TestMethod]
        public void SimpleProgramCompileTest()
        {
            var program = @"
unit Main()
{
   string s = ""FooBar"";
   eval Console.WriteLine(s);
}";
            var tokens = MonadSharpLexer.Lex(program);
            var ast = MonadSharpParser.Parse(tokens);
            var emitted = MonadSharpEmitter.Emit(ast);
        }
    }
}
