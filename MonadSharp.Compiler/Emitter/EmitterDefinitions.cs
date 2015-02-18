using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Nodes;
using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens;
using MonadSharp.Syntax.Tokens.Fixed;
using MonadSharp.Syntax.Tokens.Fixed.Keywords.PredefinedTypes;

namespace MonadSharp.Compiler.Emitter
{
    public static class EmitterDefinitions
    {
        public static string Emit(IdentifierNameNode identifier)
        {
            return identifier.Name.TokenValue;
        }

        public static string EmitCheckForSystemType(IdentifierNameNode identifier, bool isSerial)
        {
            var name = identifier.Name.TokenValue;
            //if (isSerial)
            //    return name;

            if (name == "Console")
                return "_" + name;
            return name;
        }

        public static string Emit(Scope scope, BlockNode block)
        {
            var currentScope = new Scope(scope.IdentifierIndex);
            var sb = new StringBuilder();
            sb.AppendLine("{");
            foreach (var statementNode in block.Statements)
            {
                var emittedStatement = Emit(currentScope, statementNode, block.IsSerial);
                sb.AppendLine(emittedStatement);
            }

            if (!block.IsSerial)
            {
                if (currentScope.EvaluatedIdentifiers.Count > 0)
                {
                    var evalArgs =
                        currentScope.EvaluatedIdentifiers.Aggregate((left, right) => string.Format("{0}, {1}", left, right));
                    sb.AppendLine(string.Format("return ObservableEx.ForkJoin({0}).ToVoid();", evalArgs));
                }
                else
                {
                    sb.AppendLine("return Observable.Return(Unit.Default);");
                }
            }
            else
            {
                sb.AppendLine("return Observable.Return(Unit.Default);");
            }
            sb.AppendLine("}");

            scope.IdentifierIndex = currentScope.IdentifierIndex;
            return sb.ToString();
        }

        public static string Emit(Scope scope, StatementNode statementNode, bool isSerial)
        {
            if (statementNode is ExpressionStatementNode)
                return Emit((ExpressionStatementNode)statementNode, isSerial);
            if (statementNode is EvalExpressionStatementNode)
                return Emit(scope, (EvalExpressionStatementNode)statementNode, isSerial);
            if (statementNode is VariableDeclarationStatementNode)
                return Emit((VariableDeclarationStatementNode)statementNode, isSerial);
            if (statementNode is RangeNode)
                return Emit(scope, (RangeNode)statementNode, isSerial);
            if (statementNode is IfStatementNode)
                return Emit(scope, (IfStatementNode)statementNode, isSerial);
            return null;
        }

        public static string Emit(MethodDeclarationNode methodDeclarationNode)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("public static {0} {1}{2}", EmitType(Emit(methodDeclarationNode.ReturnType)), Emit(methodDeclarationNode.Name), Emit(methodDeclarationNode.ParameterList)));
            sb.AppendLine(Emit(new Scope(0), methodDeclarationNode.Block));
            if (methodDeclarationNode.Block.IsSerial)
            {
                sb.Insert(sb.Length - 5, "return Observable.Return(Unit.Default);");
            }

            return sb.ToString();
        }

        public static string Emit(ParameterListNode parameterList)
        {
            var sb = new StringBuilder();

            sb.Append("(");
            if (parameterList.Parameters != null && parameterList.Parameters.Count > 0)
            {
                var parameters = parameterList.Parameters.Select(Emit)
                    .Aggregate((left, right) => string.Format("{0}, {1}", left, right));
                sb.Append(parameters);
            }
            sb.Append(")");

            return sb.ToString();
        }

        public static string Emit(ParameterNode parameterNode)
        {
            return string.Format("{0} {1}", EmitType(parameterNode.Type.TokenValue), parameterNode.Name.TokenValue);
        }

        public static string Emit(NameToken nameToken)
        {
            return nameToken.TokenValue;
        }

        public static string Emit(PredefinedTypeNode typeNode)
        {
            if (typeNode.TypeToken is UnitToken)
                return Emit((UnitToken)typeNode.TypeToken);
            return typeNode.TypeToken.TokenValue;
        }

        public static string Emit(UnitToken typeNode)
        {
            return "Unit";
        }

        public static string Emit(ExpressionStatementNode expressionStatementNode, bool isSerial)
        {
            var statement = string.Format("{0};", Emit(expressionStatementNode.Expression, isSerial));
            return statement;
        }

        public static string Emit(Scope scope, EvalExpressionStatementNode expressionStatementNode, bool isSerial)
        {
            if (isSerial)
            {
                return string.Format("{0}.Wait();", Emit(expressionStatementNode.Expression, isSerial));
            }

            var evalName = string.Format("_{0}", scope.IdentifierIndex++);
            scope.EvaluatedIdentifiers.Add(evalName);
            var statement = string.Format("var {0} = {1};", evalName, Emit(expressionStatementNode.Expression, isSerial));
            return statement;
        }

        public static string Emit(VariableDeclarationStatementNode expressionStatementNode, bool isSerial)
        {
            var statement = string.Format("var {0};", Emit(expressionStatementNode.Declarator, isSerial));
            return statement;
        }

        public static string Emit(Scope scope, RangeNode expressionStatementNode, bool isSerial)
        {
            expressionStatementNode.Block.IsSerial = isSerial;
            //if (isSerial)
            //{
            //    return string.Format("foreach (var {0} in Enumerable.Range({1},{2})){3}",
            //                         Emit(expressionStatementNode.IndexName),
            //                         Emit(expressionStatementNode.StartExpresssion, isSerial),
            //                         Emit(expressionStatementNode.EndExpresssion, isSerial),
            //                         Emit(scope, expressionStatementNode.Block));
            //}

            var evalName = string.Format("_{0}", scope.IdentifierIndex++);
            scope.EvaluatedIdentifiers.Add(evalName);
            expressionStatementNode.Block.IsSerial = isSerial;
            var statement = string.Format(
                @"var {0} = ObservableExt.Range({1}, {2}, {3} => {4});", evalName,
                Emit(expressionStatementNode.StartExpresssion, isSerial), 
                Emit(expressionStatementNode.EndExpresssion, isSerial),
                Emit(expressionStatementNode.IndexName),
                Emit(scope, expressionStatementNode.Block));
            return statement;
        }

        public static string Emit(Scope scope, IfStatementNode expressionStatementNode, bool isSerial)
        {
            string elseBlock = string.Empty;
            expressionStatementNode.IfBlock.IsSerial = isSerial;

            if (expressionStatementNode.ElseBlock != null)
            {
                expressionStatementNode.ElseBlock.IsSerial = isSerial;
            }

            if (isSerial)
            {
                if (expressionStatementNode.ElseBlock != null)
                {
                    elseBlock = string.Format(" else {0}", Emit(scope, expressionStatementNode.ElseBlock));
                }
                return string.Format("if ({0}) {1}{2}",
                                     Emit(expressionStatementNode.BoolExpression, isSerial),
                                     Emit(scope, expressionStatementNode.IfBlock),
                                     elseBlock);
            }

            var evalName = string.Format("_{0}", scope.IdentifierIndex++);
            scope.EvaluatedIdentifiers.Add(evalName);
            if (expressionStatementNode.ElseBlock != null)
            {
                elseBlock = string.Format(", () => {0}", Emit(scope, expressionStatementNode.ElseBlock));
            }

            var statement = string.Format(
                @"var {0} = ObservableExt.If({1}, () => {2}{3});", evalName,
                Emit(expressionStatementNode.BoolExpression, isSerial),
                Emit(scope, expressionStatementNode.IfBlock),
                elseBlock);
            return statement;
        }

        private static string Emit(VariableDeclaratorNode variableDeclaratorNode, bool isSerial)
        {
            var variableDeclarator = string.Format("{0} {1}", variableDeclaratorNode.IdentifierName.Name.TokenValue,
                                                   Emit(variableDeclaratorNode.EqualsValueClause, isSerial));
            return variableDeclarator;
        }

        private static string Emit(EqualsValueClauseNode equalsValueClauseNode, bool isSerial)
        {
            var equalsValue = string.Format("= {0}", Emit(equalsValueClauseNode.Expression, isSerial));
            return equalsValue;
        }

        public static string Emit(InvocationExpressionNode invocationExpressionNode, bool isSerial)
        {
            return string.Format("{0}{1}",
                Emit(invocationExpressionNode.Expression, isSerial),
                Emit(invocationExpressionNode.ArgumentList, isSerial));
        }

        public static string Emit(ArgumentExpressionNode argumentExpressionNode, bool isSerial)
        {
            return Emit(argumentExpressionNode.Expression, isSerial);
        }

        public static string Emit(TrueLiteralExpressionNode trueLiteralExpressionNode, bool isSerial)
        {
            return EmitReturn(trueLiteralExpressionNode.TrueToken.TokenValue, isSerial);
        }

        public static string Emit(FalseLiteralExpressionNode falseLiteralExpressionNode, bool isSerial)
        {
            return EmitReturn(falseLiteralExpressionNode.FalseToken.TokenValue, isSerial);
        }

        public static string Emit(Int32LiteralExpressionNode int32LiteralExpressionNode, bool isSerial)
        {
            return EmitReturn(int32LiteralExpressionNode.Int32Token.TokenValue, isSerial);
        }

        public static string Emit(SimpleMemberAccessExpressionNode simpleMemberAccessExpressionNode, bool isSerial)
        {
            return string.Format("{0}.{1}",
                EmitCheckForSystemType(simpleMemberAccessExpressionNode.SourceMember, isSerial),
                Emit(simpleMemberAccessExpressionNode.AccessedMember));
        }

        public static string Emit(ArgumentListNode argumentListNode, bool isSerial)
        {
            var sb = new StringBuilder();

            sb.Append("(");
            if (argumentListNode.ArgumentExpressions != null && argumentListNode.ArgumentExpressions.Count > 0)
            {
                var arguments = argumentListNode.ArgumentExpressions.Select(exp => Emit(exp, isSerial))
                    .Aggregate((left, right) => string.Format("{0}, {1}", left, right));
                sb.Append(arguments);
            }
            sb.Append(")");

            return sb.ToString();
        }

        public static string Emit(ExpressionNode expression, bool isSerial)
        {
            if (expression is StringLiteralExpressionNode)
                return Emit((StringLiteralExpressionNode)expression, isSerial);
            if (expression is SimpleMemberAccessExpressionNode)
                return Emit((SimpleMemberAccessExpressionNode)expression, isSerial);
            if (expression is InvocationExpressionNode)
                return Emit((InvocationExpressionNode)expression, isSerial);
            if (expression is ArgumentExpressionNode)
                return Emit((ArgumentExpressionNode)expression, isSerial);
            if (expression is TrueLiteralExpressionNode)
                return Emit((TrueLiteralExpressionNode)expression, isSerial);
            if (expression is FalseLiteralExpressionNode)
                return Emit((FalseLiteralExpressionNode)expression, isSerial);
            if (expression is Int32LiteralExpressionNode)
                return Emit((Int32LiteralExpressionNode)expression, isSerial);
            if (expression is IdentifierNameNode)
                return ((IdentifierNameNode) expression).Name.TokenValue;
            throw new Exception();
        }

        public static string Emit(StringLiteralExpressionNode stringLiteralExpressionNode, bool isSerial)
        {
            var value = string.Format("{0}", stringLiteralExpressionNode.StringToken.TokenValue);
            return EmitReturn(value, isSerial);
        }

        private static string EmitReturn(string value, bool isSerial)
        {
            //if (isSerial)
            //    return value;
            return string.Format("Observable.Return({0})", value);
        }

        private static string EmitType(string value)
        {
            return string.Format("IObservable<{0}>", value);
        }
    }
}
