using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class PeriodToken : SyntaxToken
    {
        public const string TokenName = "Period";

        public PeriodToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
