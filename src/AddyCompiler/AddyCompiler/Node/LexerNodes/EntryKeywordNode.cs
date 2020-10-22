using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class EntryKeywordNode : KeywordNode
	{

		public EntryKeywordNode(int row, int col) : base(NodeType.EntryKeywordNode, "entry", row, col) { }
	}
}
