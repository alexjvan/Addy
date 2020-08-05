using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class EqualsNode : PunctuationNode
	{
		public EqualsNode(int row, int col) : base(NodeType.EqualsToken, '=', row, col) { }
	}
}
