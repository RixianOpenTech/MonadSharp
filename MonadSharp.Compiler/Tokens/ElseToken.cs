using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class ElseToken : Token
    {
        public const string TokenName = "Else";

        public ElseToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
