using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class LogicNode : ValueNode<bool>
	{
		public LogicNode(bool value, int row, int col) : base(NodeType.LogicNode, value, row, col) { }
	}
}
