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
		RequiredAndNode<
			RequiredNode<IdentifierNode>,
			RequiredAndNode<
				RequiredNode<ManipulatingEqualsNode>,
				RequiredAndNode<
					RequiredOrNode<
						RequiredNode<VariableValueNode>,
						RequiredNode<FunctionCallNode>
					>,
					RequiredNode<SemiColonNode>
				>
			>
		>
	>
	{

		public VariableManipulationNode(int rowStart, int colStart) : base(NodeType.VariableManipulationNode, rowStart, colStart) { }

		public VariableManipulationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.VariableManipulationNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
