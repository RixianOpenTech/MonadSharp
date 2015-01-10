using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class WhileToken : SyntaxToken
    {
        public const string TokenName = "While";

        public WhileToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
