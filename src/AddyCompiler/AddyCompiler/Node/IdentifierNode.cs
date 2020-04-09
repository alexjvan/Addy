using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class IdentifierNode : ValueNode<string>
	{
		public IdentifierNode(string value, int row, int col) : base(NodeType.IdentifierNode, value, row, col) { }
	}
}
