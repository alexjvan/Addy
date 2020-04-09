using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class DivisionNode : OperatorNode
	{
		public DivisionNode(int row, int col) : base(NodeType.DivisionToken, '/', row, col) { }
	}
}
