using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Syntax.Tokens.Abstract
{
    public interface ISyntaxToken
    {
        string TokenValue { get; }
    }
}
