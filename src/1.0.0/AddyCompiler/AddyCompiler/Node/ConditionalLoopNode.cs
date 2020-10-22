using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ConditionalLoopNode : ParserNode<
		// do (condition) {...} while;
		// for('vardec';'condition';'varmanipulate') {...}
		// while (condition) {...}
		RequiredOrNode<
			// for
			RequiredAndNode<
				RequiredAndNode<
					RequiredAndNode<
						RequiredAndNode<
							RequiredNode<ForKeywordNode>,
							RequiredNode<OpenParenthesisNode>
						>,
						RequiredAndNode<
							RequiredOrNode<
								NullNode,
								RequiredNode<VariableDeclarationNode>
							>,
							RequiredNode<SemiColonNode>
						>
					>,
					RequiredAndNode<
						RequiredAndNode<
							RequiredOrNode<
								NullNode,
								RequiredNode<ConditionNode>
							>,
							RequiredNode<SemiColonNode>
						>,
						RequiredOrNode<
							NullNode,
							RequiredNode<VariableManipulationNode>
						>
					>
				>,
				RequiredAndNode<
					RequiredAndNode<
						RequiredNode<CloseParenthesisNode>,
						RequiredNode<OpenBracketNode>
					>,
					RequiredAndNode<
						RequiredNode<EndlessGenericStatementNode>,
						RequiredNode<CloseBracketNode>
					>
				>
			>,
			// do / while
			RequiredOrNode<
				RequiredAndNode<
					RequiredAndNode<
						RequiredAndNode<
							RequiredAndNode<
								RequiredNode<DoNode>,
								RequiredNode<OpenParenthesisNode>
							>,
							RequiredNode<ConditionNode>
						>,
						RequiredAndNode<
							RequiredNode<CloseParenthesisNode>,
							RequiredNode<OpenBracketNode>
						>
					>,
					RequiredAndNode<
						RequiredAndNode<
							RequiredNode<EndlessGenericStatementNode>,
							RequiredNode<CloseBracketNode>
						>,
						RequiredAndNode<
							RequiredNode<WhileNode>,
							RequiredNode<SemiColonNode>
						>
					>
				>,
				RequiredAndNode<
					RequiredAndNode<
						RequiredAndNode<
							RequiredNode<WhileNode>,
							RequiredNode<OpenParenthesisNode>
						>,
						RequiredNode<ConditionNode>
					>,
					RequiredAndNode<
						RequiredAndNode<
							RequiredNode<CloseParenthesisNode>,
							RequiredNode<OpenBracketNode>
						>,
						RequiredAndNode<
							RequiredNode<EndlessGenericStatementNode>,
							RequiredNode<CloseBracketNode>
						>
					>
				>
			>
		>
	>
	{

		public ConditionalLoopNode(int rowStart, int colStart) : base(NodeType.ConditionalLoopNode, rowStart, colStart) { }

		public ConditionalLoopNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ConditionalLoopNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
