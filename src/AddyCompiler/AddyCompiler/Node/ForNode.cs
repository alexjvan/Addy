using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ForNode : LoopNode
	{
		public ForNode(int row, int col) : base(NodeType.ForKeywordNode, "for", row, col) { }
	}
}
