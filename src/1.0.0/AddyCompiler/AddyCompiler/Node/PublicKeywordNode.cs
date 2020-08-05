using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class PublicKeywordNode : KeywordNode
	{

		public PublicKeywordNode(int row, int col) : base(NodeType.PublicKeywordNode, "public", row, col) { }

	}
}
