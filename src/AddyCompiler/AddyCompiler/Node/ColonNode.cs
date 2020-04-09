using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ColonNode : PunctuationNode
	{
		public ColonNode(int row, int col) : base(NodeType.ColonToken, ':', row, col) { }
	}
}
