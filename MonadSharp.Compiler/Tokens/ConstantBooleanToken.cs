using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class ConstantBooleanToken : SyntaxToken
    {
        public const string TokenName = "ConstantBoolean";

        public ConstantBooleanToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
