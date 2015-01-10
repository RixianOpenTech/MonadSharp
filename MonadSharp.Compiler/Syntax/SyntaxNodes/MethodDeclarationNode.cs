using MonadSharp.Compiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Syntax.SyntaxNodes
{
    public sealed class MethodDeclarationNode : SyntaxNode
    {
        public TypeNode ReturnType { get; set; }
        public NameToken Name { get; set; }
        public ParameterListNode ParameterList { get; set; }
        public BlockNode Block { get; set; }
    }
}
