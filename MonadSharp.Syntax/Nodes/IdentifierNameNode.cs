using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Tokens;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class IdentifierNameNode
    {
        public NameToken Name { get; set; }
    }
}
