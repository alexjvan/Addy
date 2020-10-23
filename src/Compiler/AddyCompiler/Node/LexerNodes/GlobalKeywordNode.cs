using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class GlobalKeywordNode : KeywordNode
	{

		public GlobalKeywordNode(int row, int col) : base(NodeType.GlobalKeywordNode, "global", row, col) { }

	}
}
