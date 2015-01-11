using MonadSharp.Syntax.Nodes.Abstract;

namespace MonadSharp.Syntax.Nodes
{
    public sealed class PredefinedTypeNode : TypeNode
    {
        public PredefinedTypeToken TypeToken { get; set; }
    }
}
