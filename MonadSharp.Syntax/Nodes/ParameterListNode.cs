using System.Collections.Generic;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class ParameterListNode : SyntaxNode
    {
        public ParameterListNode()
        {
            this.Parameters = new List<ParameterNode>();
        }

        public List<ParameterNode> Parameters { get; set; }
    }
}
