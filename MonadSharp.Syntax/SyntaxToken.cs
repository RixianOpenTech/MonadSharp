using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax
{
    public abstract class SyntaxToken : ISyntaxToken
    {
        protected SyntaxToken(string tokenValue)
        {
            this.TokenValue = tokenValue;
        }

        public string TokenValue { get; private set; }
    }
}
