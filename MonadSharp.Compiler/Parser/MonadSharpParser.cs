using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MonadSharp.Compiler.Tokens;
using MonadSharp.Compiler.Tokens.TokenFactories;

namespace MonadSharp.Compiler.Parser
{
    public class MonadSharpParser
    {
        static MonadSharpParser()
        {
            var currentAssembly = typeof (MonadSharpParser).GetTypeInfo().Assembly;
            var allTokens = currentAssembly.DefinedTypes.Where(info => !info.IsAbstract && info.IsSubclassOf(typeof (Token)));
        }

        public static IReadOnlyList<Token> Parse(string program)
        {
            return SplitExtensions.SplitIntoTokens(program).ToList();
        }
    }
}
