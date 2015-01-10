using MonadSharp.Compiler.Syntax.SyntaxTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Syntax.SyntaxNodes
{
    public sealed class PredefinedTypeNode : TypeNode
    {
        public PredefinedTypeToken TypeToken { get; set; }
    }
}
