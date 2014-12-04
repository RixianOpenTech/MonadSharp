using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class EqualsToken : Token
    {
        public const string TokenName = "Equals";

        public EqualsToken(string tokenValue)
            : base(tokenValue)
        {
        }
    }
}
