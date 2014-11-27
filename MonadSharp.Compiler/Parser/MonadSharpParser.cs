using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Compiler.Tokens;

namespace MonadSharp.Compiler.Parser
{
    class MonadSharpParser
    {
        static MonadSharpParser()
        {
            var currentAssembly = typeof (MonadSharpParser).GetTypeInfo().Assembly;
            var allTokens = currentAssembly.DefinedTypes.Where(info => !info.IsAbstract && info.IsSubclassOf(typeof (Token)));
        }
    }
}
