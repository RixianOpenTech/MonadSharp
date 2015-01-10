using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class GreaterThanToken : SyntaxToken
    {
        public const string TokenName = "GreaterThan";

        public GreaterThanToken(string tokenValue)
            : base(tokenValue)
        {
        }
    }
}
