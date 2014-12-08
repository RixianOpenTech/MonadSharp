using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class PercentToken : Token
    {
        public const string TokenName = "Percent";

        public PercentToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
