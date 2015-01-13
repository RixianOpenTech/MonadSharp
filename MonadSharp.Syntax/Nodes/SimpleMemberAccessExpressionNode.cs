using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens.Fixed;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class SimpleMemberAccessExpressionNode : ExpressionNode
    {
        public IdentifierNameNode SourceMember { get; set; }
        public IdentifierNameNode AccessedMember { get; set; }
    }
}
