using System;
using System.Collections.Generic;
using System.Linq;
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

        public static string Emit(BlockNode block)
        {
            var sb = new StringBuilder();

            sb.AppendLine("{");
            foreach (var statementNode in block.Statements)
            {
                sb.AppendLine(Emit(statementNode));
            }
            sb.AppendLine("}");

            return sb.ToString();
        }

        public static string Emit(StatementNode statementNode)
        {
            if (statementNode is ExpressionStatementNode)
                return Emit((ExpressionStatementNode) statementNode);
            return "???";
        }

        public static string Emit(MethodDeclarationNode methodDeclarationNode)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("{0} {1}{2}", EmitType(Emit(methodDeclarationNode.ReturnType)), Emit(methodDeclarationNode.Name), Emit(methodDeclarationNode.ParameterList)));
            sb.AppendLine(Emit(methodDeclarationNode.Block));

            return sb.ToString();
        }

        public static string Emit(ParameterListNode parameterList)
        {
            var sb = new StringBuilder();

            sb.Append("(");
            if (parameterList.Parameters != null)
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

        public static string Emit(ExpressionStatementNode expressionStatementNode)
        {
            return string.Format("{0};", Emit(expressionStatementNode.Expression));
        }

        public static string Emit(InvocationExpressionNode invocationExpressionNode)
        {
            return string.Format("{0}{1}",
                Emit(invocationExpressionNode.Expression),
                Emit(invocationExpressionNode.ArgumentList));
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
            if (argumentListNode.ArgumentExpressions != null)
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
            return "???";
        }

        public static string Emit(StringLiteralExpressionNode stringLiteralExpressionNode)
        {
            var value = string.Format("\"{0}\"", stringLiteralExpressionNode.StringToken.TokenValue);
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
