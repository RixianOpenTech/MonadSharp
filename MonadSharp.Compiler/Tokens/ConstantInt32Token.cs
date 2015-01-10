using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class ConstantInt32Token : SyntaxToken
    {
        public const string TokenName = "ConstantInt32";

        public ConstantInt32Token(string tokenValue) : base(tokenValue)
        {
        }
    }
}
