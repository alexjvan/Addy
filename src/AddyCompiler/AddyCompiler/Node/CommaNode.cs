using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class CommaNode : PunctuationNode
	{
		public CommaNode(int row, int col) : base(NodeType.CommaToken, ',', row, col) { }
	}
}
