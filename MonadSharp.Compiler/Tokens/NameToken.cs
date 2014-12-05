using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class NameToken : Token
    {
        public const string TokenName = "Name";

        public NameToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
