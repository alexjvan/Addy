using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class EndlessGenericStatementNode : ParserNode<
		RequiredOrNode<
			RequiredAndNode<
				RequiredNode<GenericStatementNode>,
				RequiredNode<EndlessGenericStatementNode>
			>,
			NullNode	
		>
	>
	{

		public EndlessGenericStatementNode(int rowStart, int colStart) : base(NodeType.EndlessGenericStatementNode, rowStart, colStart) { }

		public EndlessGenericStatementNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.EndlessGenericStatementNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
