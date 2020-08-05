using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ExclamationNode : PunctuationNode
	{
		public ExclamationNode(int row, int col) : base(NodeType.ExclamationToken, '!', row, col) { }
	}
}
