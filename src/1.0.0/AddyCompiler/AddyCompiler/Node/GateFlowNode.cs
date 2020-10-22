using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class GateFlowNode : ParserNode<
		// flow "ex": ~endlessgenericstatement~ break;
		// flow: ~~ break;
		RequiredAndNode<
			RequiredAndNode<
				RequiredAndNode<
					RequiredNode<FlowKeywordNode>,
					RequiredOrNode<
						NullNode,
						RequiredNode<VariableValueNode>
					>
				>,
				RequiredNode<ColonNode>
			>,
			RequiredAndNode<
				RequiredNode<EndlessGenericStatementNode>,
				RequiredAndNode<
					RequiredNode<BreakKeywordNode>,
					RequiredNode<SemiColonNode>
				>
			>
		>
	>
	{

		public GateFlowNode(int rowStart, int colStart) : base(NodeType.GateFlowNode, rowStart, colStart) { }

		public GateFlowNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.GateFlowNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
