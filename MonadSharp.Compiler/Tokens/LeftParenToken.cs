using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class LeftParenToken : SyntaxToken
    {
        public const string TokenName = "LeftParen";

        public LeftParenToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
