using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class WhileNode : LoopNode
	{
		public WhileNode(int row, int col) : base(NodeType.WhileKeywordNode, "while", row, col) { }
	}
}
