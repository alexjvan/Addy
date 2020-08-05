using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class CloseBracketNode : EncasementCloseNode
	{

		public CloseBracketNode(int row, int col) : base(NodeType.CloseBracketToken, '}', row, col) { }

	}
}
