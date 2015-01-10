using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Tokens
{
    public class ParallelToken : SyntaxToken
    {
        public const string TokenName = "Parallel";

        public ParallelToken(string tokenValue) : base(tokenValue)
        {
        }
    }
}
