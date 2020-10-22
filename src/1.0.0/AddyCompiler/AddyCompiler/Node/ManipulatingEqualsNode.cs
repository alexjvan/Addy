using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ManipulatingEqualsNode : ParserNode<
		// =
		// +=
		// -=
		// *=
		// /=
		RequiredAndNode<
			RequiredOrNode<
				RequiredOrNode<
					NullNode,
					RequiredOrNode<
						RequiredNode<AdditionNode>,
						RequiredNode<SubtractionNode>
					>
				>,
				RequiredOrNode<
					RequiredNode<MultiplicationNode>,
					RequiredNode<DivisionNode>
				>
			>,
			RequiredNode<EqualsNode>
		>
	>
	{

		public ManipulatingEqualsNode(int rowStart, int colStart) : base(NodeType.ManipulatingEqualsNode, rowStart, colStart) { }

		public ManipulatingEqualsNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ManipulatingEqualsNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
