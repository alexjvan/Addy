using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ClassKeywordNode : KeywordNode
	{

		public ClassKeywordNode(int row, int col) : base(NodeType.ClassKeywordNode, "class", row, col) { }

	}
}
