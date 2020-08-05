using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class OpenBraceNode : EncasementOpenNode
	{

		public OpenBraceNode(int row, int col) : base(NodeType.OpenBraceToken, '[', row, col) { }

	}
}
