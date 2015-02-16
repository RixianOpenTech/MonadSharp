using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax;
using MonadSharp.Syntax.Nodes;

namespace MonadSharp.Compiler.Emitter
{
    public static class MonadSharpEmitter
    {
        public static string Emit(SyntaxNode tree)
        {
            var sb = new StringBuilder();
            var rootSyntaxNode = (RootSyntaxNode) tree;
            foreach (var syntaxNode in rootSyntaxNode.SyntaxNodes)
            {
                sb.AppendLine(EmitterDefinitions.Emit((MethodDeclarationNode) syntaxNode));
            }
            return sb.ToString();
        }
    }
}
