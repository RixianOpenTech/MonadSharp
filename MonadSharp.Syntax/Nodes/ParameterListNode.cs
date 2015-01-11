using System.Collections.Generic;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class ParameterListNode : SyntaxNode
    {
        public List<ParameterNode> Parameters { get; set; }
    }
}
