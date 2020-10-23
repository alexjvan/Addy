using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ArgumentsNode : ParserNode<
		RequiredAndNode<
			RequiredNode<OpenParenthesisNode>,
			RequiredAndNode<
				RequiredNode<ArgumentsListNode>,
				RequiredNode<CloseParenthesisNode>
			>
		>
	>
	{

		public ArgumentsNode(int rowStart, int colStart) : base(NodeType.ArgumentsNode, rowStart, colStart) { }

		public ArgumentsNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ArgumentsNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
