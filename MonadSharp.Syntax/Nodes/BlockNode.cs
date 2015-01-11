using System.Collections.Generic;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class BlockNode
    {
        public List<StatementNode> Statements { get; set; }
    }
}
