using MonadSharp.Compiler.Syntax;
using MonadSharp.Compiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Nodes
{
    public class ParameterListNode : SyntaxNode
    {
        public List<Tuple<TypeToken, NameToken, CommaToken>> Parameters { get; private set; }

        public ParameterListNode()
        {
            Parameters = new List<Tuple<TypeToken, NameToken, CommaToken>>();
        }
    }
}
