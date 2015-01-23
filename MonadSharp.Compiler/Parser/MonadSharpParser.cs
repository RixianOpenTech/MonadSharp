using System.Collections.Generic;
using MonadSharp.Syntax;
using MonadSharp.Syntax.Nodes;
using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens;
using MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes;

namespace MonadSharp.Compiler.Parser
{
    public static class MonadSharpParser
    {
        public static SyntaxNode Parse(IEnumerable<SyntaxToken> tokens)
        {
            return new MethodDeclarationNode
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
                        new EvalExpressionStatementNode
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
                                            StringToken = new ConstantStringToken("poophead :)")
                                        }
                                    }
                                }
                            }
                        },
                        new EvalExpressionStatementNode
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
                                            StringToken = new ConstantStringToken("This is a test...")
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
