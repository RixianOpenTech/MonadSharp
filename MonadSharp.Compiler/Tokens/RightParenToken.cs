using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class RightParenToken : SyntaxToken
    {
        public const string TokenName = "RightParen";

        public RightParenToken(string tokenValue)
            : base(tokenValue)
        {
        }
    }
}
