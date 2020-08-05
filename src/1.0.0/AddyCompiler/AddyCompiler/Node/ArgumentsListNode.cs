using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ArgumentsListNode : ParserNode<
		RequiredOrNode<
			RequiredOrNode<
				RequiredNode<IdentifierNode>,
				RequiredAndNode<
					RequiredNode<IdentifierNode>,
					RequiredAndNode<
						RequiredNode<SemiColonNode>,
						RequiredNode<ArgumentsListNode>
					>
				>
			>,
			NullNode
		>
	>
	{

		public ArgumentsListNode(int rowStart, int colStart) : base(NodeType.ArgumentsListNode, rowStart, colStart) { }

		public ArgumentsListNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ArgumentsListNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
