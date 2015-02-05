using MonadSharp.Syntax.Tokens;
using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class ParameterNode : SyntaxNode
    {
        public ITypeToken Type { get; set; }
        public NameToken Name { get; set; }
    }
}
