using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ConditionNode : ParserNode<
		// Identifier|VariableValue|FunctionCall Equals|NotEquals|LessThan|GreaterThan Identifier|VariableValue|FunctionCall
		// Identifier|FunctionCall
		// 1 == 2
		// 22 != 13
		// 1 >'=' 2
		// 1 <'=' 2
		// ready (var)
		// file.isOpen() (method call)
		RequiredOrNode<
			RequiredOrNode<
				RequiredNode<IdentifierNode>,
				RequiredNode<FunctionCallNode>
			>,
			RequiredAndNode<
				RequiredOrNode<
					RequiredNode<IdentifierNode>,
					RequiredOrNode<
						RequiredNode<VariableValueNode>,
						RequiredNode<FunctionCallNode>
					>
				>,
				RequiredAndNode<
					RequiredOrNode<
						RequiredAndNode<
							RequiredAndNode<
								RequiredNode<EqualsNode>,
								RequiredNode<ExclamationNode>
							>,
							RequiredNode<EqualsNode>
						>,
						RequiredAndNode<
							RequiredOrNode<
								RequiredNode<LessThanNode>,
								RequiredNode<GreaterThanNode>
							>,
							RequiredOrNode<
								NullNode,
								RequiredNode<EqualsNode>
							>
						>
					>,
					RequiredOrNode<
						RequiredNode<IdentifierNode>,
						RequiredOrNode<
							RequiredNode<VariableValueNode>,
							RequiredNode<FunctionCallNode>
						>
					>
				>
			>
		>
	>
	{

		public ConditionNode(int rowStart, int colStart) : base(NodeType.ConditionNode, rowStart, colStart) { }

		public ConditionNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ConditionNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
