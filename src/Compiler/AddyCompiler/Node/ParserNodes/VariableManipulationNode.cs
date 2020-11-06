using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class VariableManipulationNode : ParserNode<
		// ex (+/-/*//)= "example";
		// ex (+/-/*//)= increment();
		// ex++(--);
		RequiredAndNode<
			RequiredNode<IdentifierNode>,
			RequiredOrNode<
				RequiredAndNode<
					RequiredNode<ManipulatingEqualsNode>,
					RequiredAndNode<
						RequiredOrNode<
							RequiredNode<VariableValueNode>,
							RequiredNode<FunctionCallNode>
						>,
						RequiredNode<SemiColonNode>
					>
				>,
				RequiredOrNode<
					RequiredAndNode<
						RequiredNode<AdditionNode>,
						RequiredNode<AdditionNode>
					>,
					RequiredAndNode<
						RequiredNode<SubtractionNode>,
						RequiredNode<SubtractionNode>
					>
				>
			>
		>
	>
	{

		public VariableManipulationNode(int rowStart, int colStart) : base(NodeType.VariableManipulationNode, rowStart, colStart) { }

		public VariableManipulationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.VariableManipulationNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
