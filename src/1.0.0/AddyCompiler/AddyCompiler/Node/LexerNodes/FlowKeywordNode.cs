using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class FlowKeywordNode : StatementNode
	{
		public FlowKeywordNode(int row, int col) : base(NodeType.FlowKeywordNode, "flow", row, col) { }
	}
}
