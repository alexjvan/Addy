using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class BreakKeywordNode : KeywordNode
	{

		public BreakKeywordNode(int row, int col) : base(NodeType.BreakKeywordNode, "break", row, col) { }

	}
}
