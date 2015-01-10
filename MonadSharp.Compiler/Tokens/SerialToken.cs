using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class SerialToken : SyntaxToken
    {
        public const string TokenName = "Serial";

        public SerialToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
