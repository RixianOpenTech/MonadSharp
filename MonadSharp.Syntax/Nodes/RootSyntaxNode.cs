using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class RootSyntaxNode : SyntaxNode
    {
        public List<SyntaxNode> SyntaxNodes { get; private set; }

        public RootSyntaxNode()
        {
            this.SyntaxNodes = new List<SyntaxNode>();
        }
    }
}
