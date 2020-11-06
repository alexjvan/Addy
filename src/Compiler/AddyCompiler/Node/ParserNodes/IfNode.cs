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
		// if (condition) statement 'else if()...'
		RequiredAndNode<
			RequiredOrNode<
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
				RequiredAndNode<
					RequiredAndNode<
						RequiredAndNode<
							RequiredNode<IfKeywordNode>,
							RequiredNode<OpenParenthesisNode>
						>,
						RequiredNode<ConditionNode>
					>,
					RequiredAndNode<
						RequiredNode<CloseParenthesisNode>,
						RequiredNode<GenericStatementNode>
					>
				>
			>,
			RequiredOrNode<
				NullNode,
				RequiredAndNode<
					RequiredNode<ElseNode>,
					RequiredNode<IfNode>
				>
			>
		>
	>
	{

		public IfNode(int rowStart, int colStart) : base(NodeType.IfNode, rowStart, colStart) { }

		public IfNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.IfNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
