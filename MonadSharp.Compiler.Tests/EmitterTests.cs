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

        [TestMethod]
        public void SimpleLoopTest()
        {
            var program = @"
unit Main()
{
    range(x=0..10)
    {
        eval Console.WriteLine(x);
    }
}";
            var tokens = MonadSharpLexer.Lex(program);
            var ast = MonadSharpParser.Parse(tokens);
            var emitted = MonadSharpEmitter.Emit(ast);
        }

        [TestMethod]
        public void SimpleBranchTest()
        {
            var program = @"
unit Main()
{
    if(true)
    {
        eval Console.WriteLine(""This is true..."");
    }
    else
    {
        eval Console.WriteLine(""This is false..."");
    }
}";
            var tokens = MonadSharpLexer.Lex(program);
            var ast = MonadSharpParser.Parse(tokens);
            var emitted = MonadSharpEmitter.Emit(ast);
        }
    }
}
