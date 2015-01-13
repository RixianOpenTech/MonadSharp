using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonadSharp.Syntax.Tokens;
using MonadSharp.Syntax.Tokens.Fixed.BinaryOperators;
using MonadSharp.Syntax.Tokens.TokenFactories;

namespace MonadSharp.Compiler.Tests
{
    [TestClass]
    public class TokenGeneratorTests
    {
        private string SampleProgram = @"
class Foo
{
    int x = 12345;
    unit Work(string blah)
    {
        int x = 2 + 3;
    }
}
";
        [TestMethod]
        public void Test1()
        {
            var token = TokenFactory.CreateToken("*");
            Assert.IsInstanceOfType(token, typeof(AsteriskToken));
        }

        [TestMethod]
        public void Test12()
        {
            var token = TokenFactory.CreateToken("12345");
            Assert.IsInstanceOfType(token, typeof(ConstantInt32Token));
        }

        [TestMethod]
        public void Test123()
        {
            var token = TokenFactory.CreateToken("\"12345\"");
            Assert.IsInstanceOfType(token, typeof(ConstantStringToken));
        }

        [TestMethod]
        public void Test1234()
        {
            var strings = SampleProgram.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);
            var tokens = strings.Select(TokenFactory.CreateToken).ToList();
        }
    }
}
