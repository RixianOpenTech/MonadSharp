using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Syntax.SyntaxNodes
{
    public sealed class ParameterNode : SyntaxNode
    {
        public TypeToken Type { get; set; }
        public NameToken Name { get; set; }
    }
}
