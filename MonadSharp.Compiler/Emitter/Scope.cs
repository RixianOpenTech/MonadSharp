using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Emitter
{
    public sealed class Scope
    {
        public List<string> EvaluatedIdentifiers { get; private set; }
        public Scope()
        {
            this.EvaluatedIdentifiers = new List<string>();
        }
    }
}
