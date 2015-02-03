using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Syntax.Nodes
{
    public class LocalDeclarationStatementNode : StatementNode
    {
        public VariableDeclarationNode VariableDeclaration { get; set; }
    }
}
