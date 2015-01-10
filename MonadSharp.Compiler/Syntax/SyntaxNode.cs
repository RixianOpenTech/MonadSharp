using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Syntax
{
    public abstract class SyntaxNode
    {
        public SyntaxNode ParentNode { get; set; }
        public SyntaxKind Kind { get; set; }
    }
}
