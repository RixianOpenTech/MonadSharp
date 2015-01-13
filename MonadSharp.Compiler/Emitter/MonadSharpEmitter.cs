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
            return EmitterDefinitions.Emit((MethodDeclarationNode)tree);
        }
    }
}
