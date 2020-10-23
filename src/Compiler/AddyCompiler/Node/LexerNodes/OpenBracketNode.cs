using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class OpenBracketNode : EncasementOpenNode
	{

		public OpenBracketNode(int row, int col) : base(NodeType.OpenBracketToken, '{', row, col) { }

	}
}
