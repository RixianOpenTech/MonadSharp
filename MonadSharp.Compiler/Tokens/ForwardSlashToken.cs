using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class ForwardSlashToken : SyntaxToken
    {
        public const string TokenName = "ForwardSlash";

        public ForwardSlashToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
