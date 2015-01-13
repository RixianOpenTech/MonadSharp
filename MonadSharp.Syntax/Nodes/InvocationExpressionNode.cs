using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Nodes.Abstract;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class InvocationExpressionNode : ExpressionNode
    {
        public ArgumentListNode ArgumentList { get; set; }
        public ExpressionNode Expression { get; set; }
    }
}
