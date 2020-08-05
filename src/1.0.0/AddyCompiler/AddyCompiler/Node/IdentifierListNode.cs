using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class IdentifierListNode : ParserNode<
		RequiredOrNode<
			RequiredOrNode<
				RequiredNode<IdentifierNode>,
				RequiredAndNode<
					RequiredNode<IdentifierNode>,
					RequiredAndNode<
						RequiredNode<CommaNode>,
						RequiredNode<IdentifierListNode>
					>
				>
			>,
			NullNode
		>	
	>
	{

		public IdentifierListNode(int rowStart, int colStart) : base(NodeType.IdentifierListNode, rowStart, colStart) { }

		public IdentifierListNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.IdentifierListNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
