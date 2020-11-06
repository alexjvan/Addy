using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ImportBlockNode : ParserNode<
		RequiredAndNode<
			RequiredOrNode<
				NullNode,
				RequiredNode<ImportNode>
			>,
			RequiredNode<ImportBlockNode>
		>
	>
	{

		public ImportBlockNode(int rowStart, int colStart) : base(NodeType.ImportBlockNode, rowStart, colStart) { }

		public ImportBlockNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ImportBlockNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
