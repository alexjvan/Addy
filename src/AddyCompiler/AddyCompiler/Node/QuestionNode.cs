using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class QuestionNode : PunctuationNode
	{
		public QuestionNode(int row, int col) : base(NodeType.QuestionToken, '?', row, col) { }
	}
}
