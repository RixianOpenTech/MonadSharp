using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class UnknownToken : Token
    {
        public const string TokenName = "Unknown";

        public UnknownToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
