using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class CloseBraceNode : EncasementCloseNode
	{

		public CloseBraceNode(int row, int col) : base(NodeType.CloseBraceToken, ']', row, col) { }

	}
}
