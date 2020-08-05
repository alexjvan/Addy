using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ImportKeywordNode : KeywordNode
	{
		
		public ImportKeywordNode(int row, int col) : base(NodeType.ImportKeywordNode, "import", row, col) { }

	}
}
