using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class PeriodNode : PunctuationNode
	{
		public PeriodNode(int row, int col) : base(NodeType.PeriodToken, '.', row, col) { }
	}
}
