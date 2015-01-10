using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class UnitToken : TypeToken
    {
        public const string TokenName = "Unit";

        public UnitToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
