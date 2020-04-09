using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ElseNode : StatementNode
	{
		public ElseNode(int row, int col) : base(NodeType.ElseKeywordNode, "else", row, col) { }
	}
}
