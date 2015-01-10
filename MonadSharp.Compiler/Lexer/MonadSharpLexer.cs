﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MonadSharp.Compiler.Parser;
using MonadSharp.Compiler.Tokens;

namespace MonadSharp.Compiler.Lexer
{
    public class MonadSharpLexer
    {
        static MonadSharpLexer()
        {
            var currentAssembly = typeof (MonadSharpLexer).GetTypeInfo().Assembly;
            var allTokens = currentAssembly.DefinedTypes.Where(info => !info.IsAbstract && info.IsSubclassOf(typeof (Token)));
        }

        public static IReadOnlyList<Token> Parse(string program)
        {
            return SplitExtensions.SplitIntoTokens(program).ToList();
        }
    }
}