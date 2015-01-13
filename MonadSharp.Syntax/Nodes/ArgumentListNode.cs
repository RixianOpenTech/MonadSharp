using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Nodes.Abstract;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class ArgumentListNode
    {
        public ArgumentListNode()
        {
            this.ArgumentExpressions = new List<ExpressionNode>();
        }
        public List<ExpressionNode> ArgumentExpressions { get; set; }
    }
}
