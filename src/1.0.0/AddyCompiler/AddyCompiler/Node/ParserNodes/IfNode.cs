using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class IfNode : ParserNode<
		// if (condition) {...} 'else 'if (condition)' {...}
		RequiredAndNode<
			RequiredAndNode<
				RequiredAndNode<
					RequiredAndNode<
						RequiredNode<IfKeywordNode>,
						RequiredNode<OpenParenthesisNode>
					>,
					RequiredAndNode<
						RequiredNode<ConditionNode>,
						RequiredNode<CloseParenthesisNode>
					>
				>,
				RequiredAndNode<
					RequiredAndNode<
						RequiredNode<OpenBracketNode>,
						RequiredNode<EndlessGenericStatementNode>
					>,
					RequiredNode<CloseBracketNode>
				>
			>,
			RequiredOrNode<
				NullNode,
				RequiredAndNode<
					RequiredNode<ElseNode>,
					RequiredOrNode<
						RequiredNode<IfNode>,
						RequiredAndNode<
							RequiredAndNode<
								RequiredNode<OpenBracketNode>,
								RequiredNode<EndlessGenericStatementNode>
							>,
							RequiredNode<CloseBracketNode>
						>
					>
				>
			>
		>
	>
	{

		public IfNode(int rowStart, int colStart) : base(NodeType.IfNode, rowStart, colStart) { }

		public IfNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.IfNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
