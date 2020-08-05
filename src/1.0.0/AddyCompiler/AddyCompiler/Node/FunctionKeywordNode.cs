using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class FunctionKeywordNode : KeywordNode
	{

		public FunctionKeywordNode(int row, int col) : base(NodeType.FunctionKeywordNode, "fun", row, col) { }

	}
}
