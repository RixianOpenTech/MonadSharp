using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class SemicolonToken : SyntaxToken
    {
        public const string TokenName = "Semicolon";

        public SemicolonToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
