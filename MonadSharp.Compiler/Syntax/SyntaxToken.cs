using MonadSharp.Compiler.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    [DebuggerDisplay("{TokenValue}")]
    public abstract class SyntaxToken
    {
        public string TokenValue { get; set; }
        public SyntaxNode ParentNode { get; set; }

        protected SyntaxToken(string tokenValue)
        {
            TokenValue = tokenValue;
        }
    }
}
