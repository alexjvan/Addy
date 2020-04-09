using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class LetterKeywordNode : KeywordNode
	{
		public LetterKeywordNode(int row, int col) : base(NodeType.LetterKeywordNode, "letter", row, col) { }
	}
}
