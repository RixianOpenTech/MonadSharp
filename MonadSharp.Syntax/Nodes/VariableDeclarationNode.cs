using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Nodes
{
    public class VariableDeclarationNode
    {
        public TypeToken VariableType { get; set; }
        public VariableDeclaratorNode Declarator { get; set; }
    }
}
