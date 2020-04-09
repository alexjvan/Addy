using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class NumNode : ValueNode<float>
	{
		public NumNode(float value, int row, int col) : base(NodeType.NumNode, value, row, col) { }
	}
}
