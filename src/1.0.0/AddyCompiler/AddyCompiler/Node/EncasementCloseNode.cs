using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class EncasementCloseNode : PunctuationNode
	{
		public EncasementCloseNode(NodeType type, char val, int row, int col) : base(type, val, row, col) { }
	}
}
