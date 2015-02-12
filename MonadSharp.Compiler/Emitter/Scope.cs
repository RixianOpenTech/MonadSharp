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
        public int IdentifierIndex { get; set; }
        public bool Serial { get; private set; }
        public Scope(int identifierIndex, bool serial = false)
        {
            this.EvaluatedIdentifiers = new List<string>();
            this.IdentifierIndex = identifierIndex;
            this.Serial = serial;
        }
    }
}
