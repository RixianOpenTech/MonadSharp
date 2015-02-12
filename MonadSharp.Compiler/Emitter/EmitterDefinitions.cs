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

        public static string EmitCheckForSystemType(IdentifierNameNode identifier)
        {
            var name = identifier.Name.TokenValue;
            if (name == "Console")
                return "_" + name;
            return name;
        }

        public static string Emit(Scope scope, BlockNode block)
        {
            var currentScope = new Scope(scope.IdentifierIndex + 1);
            var sb = new StringBuilder();
            sb.AppendLine("{");
            foreach (var statementNode in block.Statements)
            {
                var emittedStatement = Emit(currentScope, statementNode);
                sb.AppendLine(emittedStatement);
            }

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
            sb.AppendLine("}");

            return sb.ToString();
        }

        public static string Emit(Scope scope, StatementNode statementNode)
        {
            if (statementNode is ExpressionStatementNode)
                return Emit(scope, (ExpressionStatementNode)statementNode);
            if (statementNode is EvalExpressionStatementNode)
                return Emit(scope, (EvalExpressionStatementNode)statementNode);
            if (statementNode is VariableDeclarationStatementNode)
                return Emit(scope, (VariableDeclarationStatementNode)statementNode);
            if (statementNode is RangeNode)
                return Emit(scope, (RangeNode)statementNode);
            return null;
        }

        public static string Emit(MethodDeclarationNode methodDeclarationNode)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("public static {0} {1}{2}", EmitType(Emit(methodDeclarationNode.ReturnType)), Emit(methodDeclarationNode.Name), Emit(methodDeclarationNode.ParameterList)));
            sb.AppendLine(Emit(new Scope(0), methodDeclarationNode.Block));

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
            return string.Format("{0} {1}", parameterNode.Type, parameterNode.Name);
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

        public static string Emit(Scope scope, ExpressionStatementNode expressionStatementNode)
        {
            var statement = string.Format("{0};", Emit(expressionStatementNode.Expression));
            return statement;
        }

        public static string Emit(Scope scope, EvalExpressionStatementNode expressionStatementNode)
        {
            var evalName = string.Format("_{0}", scope.IdentifierIndex++);
            scope.EvaluatedIdentifiers.Add(evalName);
            var statement = string.Format("var {0} = {1};", evalName, Emit(expressionStatementNode.Expression));
            return statement;
        }

        public static string Emit(Scope scope, VariableDeclarationStatementNode expressionStatementNode)
        {
            var statement = string.Format("IObservable<{0}> {1};", expressionStatementNode.VariableType.TokenValue, Emit(expressionStatementNode.Declarator));
            return statement;
        }

        public static string Emit(Scope scope, RangeNode expressionStatementNode)
        {
            var evalName = string.Format("_{0}", scope.IdentifierIndex++);
            scope.EvaluatedIdentifiers.Add(evalName);
            var statement = string.Format(
                @"var {0} = ObservableExt.Range({1}, {2}).Select({3} => {4}).Flatten();", evalName,
                Emit(expressionStatementNode.StartExpresssion), 
                Emit(expressionStatementNode.EndExpresssion),
                Emit(expressionStatementNode.IndexName),
                Emit(new Scope(scope.IdentifierIndex), expressionStatementNode.Block));
            return statement;
        }

        private static string Emit(VariableDeclaratorNode variableDeclaratorNode)
        {
            var variableDeclarator = string.Format("{0} {1}", variableDeclaratorNode.IdentifierName.Name.TokenValue,
                Emit(variableDeclaratorNode.EqualsValueClause));
            return variableDeclarator;
        }

        private static string Emit(EqualsValueClauseNode equalsValueClauseNode)
        {
            var equalsValue = string.Format("= {0}", Emit(equalsValueClauseNode.Expression));
            return equalsValue;
        }

        public static string Emit(InvocationExpressionNode invocationExpressionNode)
        {
            return string.Format("{0}{1}",
                Emit(invocationExpressionNode.Expression),
                Emit(invocationExpressionNode.ArgumentList));
        }

        public static string Emit(ArgumentExpressionNode argumentExpressionNode)
        {
            return Emit(argumentExpressionNode.Expression);
        }

        public static string Emit(TrueLiteralExpressionNode trueLiteralExpressionNode)
        {
            return EmitReturn(trueLiteralExpressionNode.TrueToken.TokenValue);
        }

        public static string Emit(FalseLiteralExpressionNode falseLiteralExpressionNode)
        {
            return EmitReturn(falseLiteralExpressionNode.FalseToken.TokenValue);
        }

        public static string Emit(Int32LiteralExpressionNode int32LiteralExpressionNode)
        {
            return EmitReturn(int32LiteralExpressionNode.Int32Token.TokenValue);
        }

        public static string Emit(SimpleMemberAccessExpressionNode simpleMemberAccessExpressionNode)
        {
            return string.Format("{0}.{1}",
                EmitCheckForSystemType(simpleMemberAccessExpressionNode.SourceMember),
                Emit(simpleMemberAccessExpressionNode.AccessedMember));
        }

        public static string Emit(ArgumentListNode argumentListNode)
        {
            var sb = new StringBuilder();

            sb.Append("(");
            if (argumentListNode.ArgumentExpressions != null && argumentListNode.ArgumentExpressions.Count > 0)
            {
                var arguments = argumentListNode.ArgumentExpressions.Select(Emit)
                    .Aggregate((left, right) => string.Format("{0}, {1}", left, right));
                sb.Append(arguments);
            }
            sb.Append(")");

            return sb.ToString();
        }

        public static string Emit(ExpressionNode expression)
        {
            if (expression is StringLiteralExpressionNode)
                return Emit((StringLiteralExpressionNode)expression);
            if (expression is SimpleMemberAccessExpressionNode)
                return Emit((SimpleMemberAccessExpressionNode)expression);
            if (expression is InvocationExpressionNode)
                return Emit((InvocationExpressionNode)expression);
            if (expression is ArgumentExpressionNode)
                return Emit((ArgumentExpressionNode)expression);
            if (expression is TrueLiteralExpressionNode)
                return Emit((TrueLiteralExpressionNode)expression);
            if (expression is FalseLiteralExpressionNode)
                return Emit((FalseLiteralExpressionNode)expression);
            if (expression is Int32LiteralExpressionNode)
                return Emit((Int32LiteralExpressionNode)expression);
            if (expression is IdentifierNameNode)
                return ((IdentifierNameNode) expression).Name.TokenValue;
            throw new Exception();
        }

        public static string Emit(StringLiteralExpressionNode stringLiteralExpressionNode)
        {
            var value = string.Format("{0}", stringLiteralExpressionNode.StringToken.TokenValue);
            return EmitReturn(value);
        }

        private static string EmitReturn(string value)
        {
            return string.Format("Observable.Return({0})", value);
        }

        private static string EmitType(string value)
        {
            return string.Format("IObservable<{0}>", value);
        }
    }
}
