using MonadSharp.Compiler.Syntax;
using MonadSharp.Compiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Nodes
{
    public class MethodDeclarationNode : SyntaxNode
    {
        public TypeToken ReturnType { get; set; }
        public NameToken MethodName { get; set; }
        public LeftParenToken LeftParen { get; set; }
        public RightParenToken RightParen { get; set; }
    }
}
