using System;
using System.Collections.Generic;
using System.Linq;
using MonadSharp.Syntax;
using MonadSharp.Syntax.Nodes;
using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens;
using MonadSharp.Syntax.Tokens.Abstract;
using MonadSharp.Syntax.Tokens.Fixed;
using MonadSharp.Syntax.Tokens.Fixed.Keywords;
using MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes;

namespace MonadSharp.Compiler.Parser
{
    public static class MonadSharpParser
    {
        public static SyntaxNode Parse(IEnumerable<SyntaxToken> tokens)
        {
            var remainingTokens = tokens.ToList();
            if (!ValidateGroups(remainingTokens))
                throw new Exception();

            int index = 0;
            //foreach (var token in remainingTokens)
            //{
            //}

            return ParseMethodDeclarationNode(remainingTokens, ref index);
        }

        private static MethodDeclarationNode ParseMethodDeclarationNode(IReadOnlyList<SyntaxToken> tokens, ref int index)
        {
            var node = new MethodDeclarationNode();

            node.ReturnType = new PredefinedTypeNode
            {
                TypeToken = (IPredefinedTypeToken)tokens[index++]
            };
            node.Name = (NameToken)tokens[index++];
            node.ParameterList = ParseParameterListNode(tokens, ref index);
            node.Block = ParseBlockNode(tokens, ref index);

            return node;
        }

        private static ParameterListNode ParseParameterListNode(IReadOnlyList<SyntaxToken> tokens, ref int index)
        {
            var node = new ParameterListNode();

            index++; // Skip the left paren
            while (tokens[index] is RightParenToken == false)
            {
                var paramNode = new ParameterNode();
                paramNode.Type = (ITypeToken)tokens[index++];
                paramNode.Name = (NameToken)tokens[index++];
                node.Parameters.Add(paramNode);
            }
            index++; // Skip the right paren

            return node;
        }

        private static BlockNode ParseBlockNode(IReadOnlyList<SyntaxToken> tokens, ref int index)
        {
            var node = new BlockNode();

            index++; // Skip the left brace
            while (tokens[index] is RightCurlyBraceToken == false)
            {
                var statementNode = ParseStatementNode(tokens, ref index);
                node.Statements.Add(statementNode);
            }
            index++; // Skip the right brace

            return node;
        }

        private static StatementNode ParseStatementNode(IReadOnlyList<SyntaxToken> tokens, ref int index)
        {
            var currentToken = tokens[index];
            StatementNode node = null;

            if (currentToken is ITypeToken && tokens[index + 1] is NameToken)
            {
                node = ParseVariableDeclarationStatementNode(tokens, ref index);
            }

            index++; //Skip the semicolon
            return node;
        }

        private static VariableDeclarationStatementNode ParseVariableDeclarationStatementNode(IReadOnlyList<SyntaxToken> tokens, ref int index)
        {
            var node = new VariableDeclarationStatementNode
            {
                VariableType = (ITypeToken) tokens[index++]
            };
            node.Declarator = ParseVariableDeclaratorNode(tokens, ref index);

            return node;
        }

        private static VariableDeclaratorNode ParseVariableDeclaratorNode(IReadOnlyList<SyntaxToken> tokens, ref int index)
        {
            var node = new VariableDeclaratorNode();

            node.IdentifierName = new IdentifierNameNode
            {
                Name = (NameToken) tokens[index++]
            };
            node.EqualsValueClause = ParseEqualsValueClauseNode(tokens, ref index);

            return node;
        }

        private static EqualsValueClauseNode ParseEqualsValueClauseNode(IReadOnlyList<SyntaxToken> tokens, ref int index)
        {
            var node = new EqualsValueClauseNode();
            
            index++; //Skip the equals sign
            node.Expression = ParseExpressionNode(tokens, ref index);

            return node;
        }

        private static ExpressionNode ParseExpressionNode(IReadOnlyList<SyntaxToken> tokens, ref int index)
        {
            var currentToken = tokens[index++];

            if (currentToken is ConstantInt32Token)
            {
                return new Int32LiteralExpressionNode
                {
                    Int32Token = (ConstantInt32Token) currentToken
                };
            }
            else if (currentToken is ConstantStringToken)
            {
                return new StringLiteralExpressionNode
                {
                    StringToken = (ConstantStringToken)currentToken
                };
            }
            else if (currentToken is TrueTypeToken)
            {

                return new TrueLiteralExpressionNode
                {
                    TrueToken = (TrueTypeToken) currentToken
                };
            }
            else if (currentToken is FalseToken)
            {
                return new FalseLiteralExpressionNode
                {
                    FalseToken = (FalseToken)currentToken
                };

            }

            return null;
        }

        //public static SyntaxNode Parse(IEnumerable<SyntaxToken> tokens)
        //{
        //    return new MethodDeclarationNode
        //    {
        //        Name = new NameToken("Main"),
        //        ParameterList = new ParameterListNode(),
        //        ReturnType = new PredefinedTypeNode
        //        {
        //            ITypeToken = new UnitToken()
        //        },
        //        Block = new BlockNode
        //        {
        //            Statements = new List<StatementNode>
        //            {
        //                new EvalExpressionStatementNode
        //                {
        //                    Expression = new InvocationExpressionNode
        //                    {
        //                        Expression = new SimpleMemberAccessExpressionNode
        //                        {
        //                            SourceMember = new IdentifierNameNode
        //                            {
        //                                Name = new NameToken("Console")
        //                            },
        //                            AccessedMember = new IdentifierNameNode
        //                            {
        //                                Name = new NameToken("WriteLine")
        //                            }
        //                        },
        //                        ArgumentList = new ArgumentListNode
        //                        {
        //                            ArgumentExpressions = new List<ExpressionNode>
        //                            {
        //                                new StringLiteralExpressionNode
        //                                {
        //                                    StringToken = new ConstantStringToken("poophead :)")
        //                                }
        //                            }
        //                        }
        //                    }
        //                },
        //                new EvalExpressionStatementNode
        //                {
        //                    Expression = new InvocationExpressionNode
        //                    {
        //                        Expression = new SimpleMemberAccessExpressionNode
        //                        {
        //                            SourceMember = new IdentifierNameNode
        //                            {
        //                                Name = new NameToken("Console")
        //                            },
        //                            AccessedMember = new IdentifierNameNode
        //                            {
        //                                Name = new NameToken("WriteLine")
        //                            }
        //                        },
        //                        ArgumentList = new ArgumentListNode
        //                        {
        //                            ArgumentExpressions = new List<ExpressionNode>
        //                            {
        //                                new StringLiteralExpressionNode
        //                                {
        //                                    StringToken = new ConstantStringToken("This is a test...")
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    };
        //}

        private static bool ValidateGroups(IReadOnlyList<SyntaxToken> tokens)
        {
            var leftCurlyCount = tokens.OfType<LeftCurlyBraceToken>().Count();
            var rightCurlyCount = tokens.OfType<RightCurlyBraceToken>().Count();
            if (leftCurlyCount != rightCurlyCount)
                return false;

            var leftParenCount = tokens.OfType<LeftParenToken>().Count();
            var rightParenCount = tokens.OfType<RightParenToken>().Count();
            if (leftParenCount != rightParenCount)
                return false;

            return true;
        }
    }
}
