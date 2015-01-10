using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class CommaToken : SyntaxToken
    {
        public const string TokenName = "Comma";

        public CommaToken(string tokenValue)
            : base(tokenValue)
        {
        }
    }
}
