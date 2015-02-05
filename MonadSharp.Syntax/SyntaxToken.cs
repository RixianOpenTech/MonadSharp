using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Syntax
{
    public abstract class SyntaxToken
    {
        protected SyntaxToken(string tokenValue)
        {
            this.TokenValue = tokenValue;
        }

        public string TokenValue { get; private set; }
    }
}
