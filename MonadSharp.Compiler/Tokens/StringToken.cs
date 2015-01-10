using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class StringToken : TypeToken
    {
        public const string TokenName = "String";

        public StringToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
