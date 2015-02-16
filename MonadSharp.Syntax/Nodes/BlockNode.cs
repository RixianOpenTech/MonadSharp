using System.Collections.Generic;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class BlockNode
    {
        public List<StatementNode> Statements { get; set; }
        public bool IsSerial { get; set; }

        public BlockNode()
        {
            this.Statements = new List<StatementNode>();
        }
    }
}
