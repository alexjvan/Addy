using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class DoNode : LoopNode
	{
		public DoNode(int row, int col) : base(NodeType.DoKeywordNode, "do", row, col) { }
	}
}
