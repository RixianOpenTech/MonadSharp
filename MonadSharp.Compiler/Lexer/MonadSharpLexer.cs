using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MonadSharp.Compiler.Parser;
using MonadSharp.Syntax;

namespace MonadSharp.Compiler.Lexer
{
    public class MonadSharpLexer
    {
        static MonadSharpLexer()
        {
            var currentAssembly = typeof (MonadSharpLexer).GetTypeInfo().Assembly;
            var allTokens = currentAssembly.DefinedTypes.Where(info => !info.IsAbstract && info.IsSubclassOf(typeof (SyntaxToken)));
        }

        public static IReadOnlyList<SyntaxToken> Parse(string program)
        {
            return SplitExtensions.SplitIntoTokens(program).ToList();
        }
    }
}
