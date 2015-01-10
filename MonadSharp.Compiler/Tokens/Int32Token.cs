using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class Int32Token : SyntaxToken
    {
        public const string TokenName = "Int32";

        public Int32Token(string tokenValue) : base(tokenValue)
        {
        }
    }
}
