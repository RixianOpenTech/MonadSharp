using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Syntax.SyntaxNodes
{
    public sealed class BlockNode
    {
        public List<StatementNode> Statements { get; set; }
    }
}
