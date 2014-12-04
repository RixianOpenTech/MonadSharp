using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    [DebuggerDisplay("{TokenValue}")]
    public abstract class Token
    {
        public string TokenValue { get; set; }

        protected Token(string tokenValue)
        {
            TokenValue = tokenValue;
        }
    }
}
