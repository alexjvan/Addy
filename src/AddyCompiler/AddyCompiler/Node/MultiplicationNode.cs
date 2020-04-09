using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class MultiplicationNode : OperatorNode
	{
		public MultiplicationNode(int row, int col) : base(NodeType.MultiplicationToken, '*', row, col) { }
	}
}
