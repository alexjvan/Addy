using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class NumKeywordNode : KeywordNode
	{
		public NumKeywordNode(int row, int col) : base(NodeType.NumKeywordNode, "num", row, col) { }
	}
}
