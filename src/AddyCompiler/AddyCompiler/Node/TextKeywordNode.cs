using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class TextKeywordNode : KeywordNode
	{
		public TextKeywordNode(int row, int col) : base(NodeType.TextKeywordNode, "text", row, col) { }
	}
}
