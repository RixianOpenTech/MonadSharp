using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Nodes.Abstract;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class IfStatementNode : StatementNode
    {
        public ExpressionNode BoolExpression { get; set; }
        public BlockNode IfBlock { get; set; }
        public BlockNode ElseBlock { get; set; }
    }
}
