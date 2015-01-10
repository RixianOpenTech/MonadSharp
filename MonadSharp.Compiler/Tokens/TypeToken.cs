using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public abstract class TypeToken : SyntaxToken
    {
        public TypeToken(string tokenValue)
            : base(tokenValue)
        {

        }
    }
}
