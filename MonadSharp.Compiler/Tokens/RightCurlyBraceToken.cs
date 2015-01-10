using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class RightCurlyBraceToken : SyntaxToken
    {
        public const string TokenName = "RightCurlyBrace";

        public RightCurlyBraceToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
