using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Syntax.Nodes
{
    public class VariableDeclaratorNode
    {
        public IdentifierNameNode IdentifierName { get; set; }
        public EqualsValueClauseNode EqualsValueClause { get; set; }
    }
}
