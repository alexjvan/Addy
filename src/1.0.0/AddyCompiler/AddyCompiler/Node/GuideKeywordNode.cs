using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class GuideKeywordNode : KeywordNode
	{

		public GuideKeywordNode(int row, int col) : base(NodeType.GuideKeywordNode, "guide", row, col) { }

	}
}
