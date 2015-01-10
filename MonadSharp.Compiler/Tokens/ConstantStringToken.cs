using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class ConstantStringToken : SyntaxToken
    {
        public const string TokenName = "ConstantString";

        public ConstantStringToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
