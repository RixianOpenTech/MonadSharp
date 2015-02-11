using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class IdentifierNameNode : ExpressionNode //Should this inherit from ExpressionNode?
    {
        public NameToken Name { get; set; }
    }
}
