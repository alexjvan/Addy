using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ReturnKeywordNode : KeywordNode
	{

		public ReturnKeywordNode(int row, int col) : base(NodeType.ReturnKeywordNode, "return", row, col) { }

	}
}
