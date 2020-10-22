using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class LessThanNode : PunctuationNode
	{
		public LessThanNode(int row, int col) : base(NodeType.LessThanToken, '<', row, col) { }
	}
}
