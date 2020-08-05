using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class OpenParenthesisNode : EncasementOpenNode
	{

		public OpenParenthesisNode(int row, int col) : base(NodeType.OpenParenthesisToken, '(', row, col) { }

	}
}
