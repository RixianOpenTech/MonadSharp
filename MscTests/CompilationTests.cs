using System;
using msc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MscTests
{
    [TestClass]
    public class CompilationTests
    {
        [TestMethod]
        public void EmptyMethodTest()
        {
            const string programText = @"
unit Main()
{
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void SingleIntVariableTest()
        {
            const string programText = @"
unit Main()
{
    int x = 5;
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void SingleStringVariableTest()
        {
            const string programText = @"
unit Main()
{
    string s = ""Foo Bar"";
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void SingleBoolVariableTest()
        {
            const string programText = @"
unit Main()
{
    bool b = true;
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void WriteLineSingleIntVariableTest()
        {
            const string programText = @"
unit Main()
{
    int x = 5;
    eval Console.WriteLine(x);
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void WriteLineSingleStringVariableTest()
        {
            const string programText = @"
unit Main()
{
    string s = ""Foo Bar"";
    eval Console.WriteLine(s);
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void WriteLineSingleBoolVariableTest()
        {
            const string programText = @"
unit Main()
{
    bool b = true;
    eval Console.WriteLine(b);
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void SimpleRangeLoopTest()
        {
            const string programText = @"
unit Main()
{
    range(i=0..10)
    {
        eval Console.WriteLine(i);
    }
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void RangeRangeLoopTest()
        {
            const string programText = @"
unit Main()
{
    range(i=0..10)
    {
        range(j=0..10)
        {
            eval Console.Write(i);
            eval Console.WriteLine(j);
        }
    }
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void SerialMethodRangeLoopTest()
        {
            const string programText = @"
serial unit Main()
{
    range(i=0..10)
    {
        eval Console.WriteLine(i);
    }
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void BranchTrueLoopTest()
        {
            const string programText = @"
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
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void BranchFalseLoopTest()
        {
            const string programText = @"
unit Main()
{
    if(false)
    {
        eval Console.WriteLine(""This is true..."");
    }
    else
    {
        eval Console.WriteLine(""This is false..."");
    }
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void SecondMethodLoopTest()
        {
            const string programText = @"
unit Main()
{
    eval Console.WriteLine(""About to print a message..."");
    eval Print(""Foo bar"");
}

unit Print(string message)
{
   eval Console.Write(""Your message: "");
   eval Console.WriteLine(message);
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }

        [TestMethod]
        public void FullProgramTest()
        {
            const string programText = @"serial unit Main()
{
	bool b = true;
	eval Console.WriteLine(b);
		
	string s = ""Hi 1234 { } = . ; world"";
	eval Console.WriteLine(s);
		
	int x = 12345;
	eval Console.WriteLine(x);

	eval Console.Write(""Enter some text: "");
	string input = Console.ReadLine();
	eval Console.WriteLine(input);

	eval ThisProgram();
	eval ThatProgram();

	eval SayHello();
}

unit ThisProgram()
{
	range(x = 0..10)
	{
		eval Print(true);
	}
}

unit ThatProgram()
{
	range(x = 0..5)
	{
		eval Print(false);
	}
}

unit Print(bool thisProgram)
{
	if (thisProgram)
	{
		eval Console.WriteLine(""Hello from this program."");
	}
	else
	{
		eval Console.WriteLine(""Hello from that program."");
	}
}

serial unit SayHello()
{
	eval Console.Write(""Please Enter Your Name: "");
	string name = Console.ReadLine();
	eval Console.Write(""Hello "");
	eval Console.WriteLine(name);
}
";
            var compilationResult = Compiler.CompileText(programText);
            Assert.IsTrue(compilationResult);
        }
    }
}
