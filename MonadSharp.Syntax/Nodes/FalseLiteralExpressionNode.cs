using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens;
using MonadSharp.Syntax.Tokens.Fixed.Keywords;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class FalseLiteralExpressionNode : ExpressionNode
    {
        public FalseToken FalseToken { get; set; }
    }
}
