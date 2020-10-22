using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public abstract class PunctuationNode : ValueNode<char>
	{
		public PunctuationNode(NodeType type, char val, int row, int col) : base(type, val, row, col) { }
	}
}
