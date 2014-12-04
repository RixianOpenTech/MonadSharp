using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class BooleanToken : Token
    {
        public const string TokenName = "Boolean";

        public BooleanToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
