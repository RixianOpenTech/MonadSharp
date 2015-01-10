using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class IfToken : SyntaxToken
    {
        public const string TokenName = "If";

        public IfToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
