using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class SubtractionNode : OperatorNode
	{
		public SubtractionNode(int row, int col) : base(NodeType.SubtractionToken, '-', row, col) { }
	}
}
