using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Nodes
{
    public class ArgumentExpressionNode : ExpressionNode
    {
        public ExpressionNode Expression { get; set; }
    }
}
