using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonadSharp.Compiler.Tests
{
    [TestClass]
    public class RoslynTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tree = CSharpSyntaxTree.ParseText(
                @"
public void Main()
{
    bool b = true;
}
");
            PrintTree(tree);
        }

        private static void PrintTree(SyntaxTree tree)
        {
            var root = tree.GetRoot();
            var children = root.ChildNodesAndTokens();
            PrintChildList(children);
        }

        private static void PrintChildList(ChildSyntaxList list, int level = 0)
        {
            const string space = "    ";
            foreach (var child in list)
            {
                Debug.WriteLine("{0}{1}", string.Concat(Enumerable.Repeat(space, level)), child.CSharpKind());
                var children = child.ChildNodesAndTokens();
                PrintChildList(children, level + 1);
            }
        }
    }
}