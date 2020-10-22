using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class LocalKeywordNode : KeywordNode
	{

		public LocalKeywordNode(int row, int col) : base(NodeType.LocalKeywordNode, "local", row, col) { }

	}
}
