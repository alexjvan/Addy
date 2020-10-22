using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ContinueKeywordNode : KeywordNode
	{

		public ContinueKeywordNode(int row, int col) : base(NodeType.ContinueKeywordNode, "continue", row, col) { }

	}
}
