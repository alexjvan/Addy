using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class SwitchNode : StatementNode
	{
		public SwitchNode(int row, int col) : base(NodeType.SwitchKeywordNode, "switch", row, col) { }
	}
}
