using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class GreaterThanNode : PunctuationNode
	{
		public GreaterThanNode(int row, int col) : base(NodeType.GreaterThanToken, '>', row, col) { }
	}
}
