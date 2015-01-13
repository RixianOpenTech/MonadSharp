using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonadSharp.Compiler.Emitter;
using MonadSharp.Syntax.Nodes;
using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens;
using MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes;
using MsSystem;

namespace MonadSharp.Compiler.Tests
{
    [TestClass]
    public class RoslynTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tree = CSharpSyntaxTree.ParseText(@"
public void Main()
{
    bool b = true;
}");
            PrintTree(tree);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax
            /*
 MethodDeclaration
    PublicKeyword
    PredefinedType
        VoidKeyword
    IdentifierToken
    ParameterList
        OpenParenToken
        CloseParenToken
    Block
        OpenBraceToken
        ExpressionStatement
            InvocationExpression
                SimpleMemberAccessExpression
                    IdentifierName
                        IdentifierToken
                    DotToken
                    IdentifierName
                        IdentifierToken
                ArgumentList
                    OpenParenToken
                    Argument
                        StringLiteralExpression
                            StringLiteralToken
                    CloseParenToken
            SemicolonToken
        CloseBraceToken
EndOfFileToken*/

            var tree = CSharpSyntaxTree.ParseText(@"
public void Main()
{
    string s = Console.ReadLine(""poop"");
}");
            PrintTree(tree);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var tree = new MethodDeclarationNode
            {
                Name = new NameToken("Main"),
                ParameterList = new ParameterListNode(),
                ReturnType = new PredefinedTypeNode
                {
                    TypeToken = new UnitToken()
                },
                Block = new BlockNode
                {
                    Statements = new List<StatementNode>
                    {
                        new ExpressionStatementNode
                        {
                            Expression = new InvocationExpressionNode
                            {
                                Expression = new SimpleMemberAccessExpressionNode
                                {
                                    SourceMember = new IdentifierNameNode
                                    {
                                        Name = new NameToken("Console")
                                    },
                                    AccessedMember = new IdentifierNameNode
                                    {
                                        Name = new NameToken("WriteLine")
                                    }
                                },
                                ArgumentList = new ArgumentListNode
                                {
                                    ArgumentExpressions = new List<ExpressionNode>
                                    {
                                        new StringLiteralExpressionNode
                                        {
                                            StringToken = new ConstantStringToken("poop")
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var output = MonadSharpEmitter.Emit(tree);
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