using MonadSharp.Compiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonadSharp.Compiler.Syntax
{
    public class SyntaxNodeOrToken
    {
        public SyntaxNode Node { get; private set; }
        public SyntaxToken Token { get; private set; }

        public bool IsNode
        {
            get { return Node != null; }
        }
        public bool IsToken
        {
            get { return !IsNode; }
        }
        public SyntaxNode Parent 
        { 
            get
            {
                if (Node != null)
                {
                    return Node.ParentNode;
                }
                else
                {
                    return Token.ParentNode;
                }
            }
        }

        public SyntaxNodeOrToken(SyntaxNode parent, SyntaxToken token)
        {
            this.Token = token;
        }

        public SyntaxNodeOrToken(SyntaxNode node)
        {
            this.Node = node;
        }
    }
}
