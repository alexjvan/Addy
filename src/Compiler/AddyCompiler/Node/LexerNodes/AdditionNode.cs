using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class AdditionNode : OperatorNode
	{
		public AdditionNode(int row, int col) : base(NodeType.AdditionToken, '+', row, col) { }
	}
}
