using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class GateKeywordNode : StatementNode
	{
		public GateKeywordNode(int row, int col) : base(NodeType.GateKeywordNode, "gate", row, col) { }
	}
}
