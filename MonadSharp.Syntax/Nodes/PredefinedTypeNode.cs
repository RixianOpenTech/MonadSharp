using MonadSharp.Syntax.Nodes.Abstract;
using MonadSharp.Syntax.Tokens.Abstract;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class PredefinedTypeNode : TypeNode
    {
        public IPredefinedTypeToken TypeToken { get; set; }
    }
}
