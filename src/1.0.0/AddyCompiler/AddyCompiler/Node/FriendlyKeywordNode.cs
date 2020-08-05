using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class FriendlyKeywordNode : KeywordNode
	{

		public FriendlyKeywordNode(int row, int col) : base(NodeType.FriendlyKeywordNode, "friendly", row, col) { }

	}
}
