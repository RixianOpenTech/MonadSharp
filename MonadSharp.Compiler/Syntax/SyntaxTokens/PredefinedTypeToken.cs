using MonadSharp.Compiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Syntax.SyntaxTokens
{
    public abstract class PredefinedTypeToken : SyntaxToken
    {
        protected PredefinedTypeToken(string tokenValue)
            : base(tokenValue)
        {
        }
    }
}
