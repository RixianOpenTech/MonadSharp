using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class LessThanToken : Token
    {
        public const string TokenName = "LessThan";

        public LessThanToken(string tokenValue)
            : base(tokenValue)
        {
        }
    }
}
