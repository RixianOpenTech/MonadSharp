using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class MethodDeclarationNode : SyntaxNode
    {
        public TypeNode ReturnType { get; set; }
        public NameToken Name { get; set; }
        public ParameterListNode ParameterList { get; set; }
        public BlockNode Block { get; set; }
    }
}
