using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class LeftCurlyBraceToken : SyntaxToken
    {
        public const string TokenName = "LeftCurlyBrace";

        public LeftCurlyBraceToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
