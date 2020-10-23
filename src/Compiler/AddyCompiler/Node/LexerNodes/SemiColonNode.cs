using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class SemiColonNode : PunctuationNode
	{
		public SemiColonNode(int row, int col) : base(NodeType.SemiColonToken, ';', row, col) { }
	}
}
