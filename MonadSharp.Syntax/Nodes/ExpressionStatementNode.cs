using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Nodes.Abstract;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class ExpressionStatementNode : StatementNode
    {
        public ExpressionNode Expression { get; set; }
    }
}
