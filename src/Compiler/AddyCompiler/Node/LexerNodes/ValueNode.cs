using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public abstract class ValueNode : SingleLocNode
	{
		public ValueNode(NodeType type, int row, int col) : base(type, row, col) { }
	}
}
