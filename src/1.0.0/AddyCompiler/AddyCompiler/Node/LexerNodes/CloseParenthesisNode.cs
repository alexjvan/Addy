using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class CloseParenthesisNode : EncasementCloseNode
	{

		public CloseParenthesisNode(int row, int col) : base(NodeType.CloseParenthesisToken, ')', row, col) { }

	}
}
