using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class RangeNode : StatementNode
    {
        public ExpressionNode StartExpresssion { get; set; }
        public NameToken IndexName { get; set; }
        public ExpressionNode EndExpresssion { get; set; }
        public BlockNode Block { get; set; }
    }
}
