using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ConditionalStatementNode : ParserNode<
		// if (condition) {...} 'else 'if (condition)' {...}'
		// gate (ex) {...}
		RequiredOrNode<
			RequiredNode<IfNode>,
			RequiredAndNode<
				RequiredNode<GateKeywordNode>,
				RequiredAndNode<
					RequiredAndNode<
						RequiredNode<OpenParenthesisNode>,
						RequiredAndNode<
							RequiredNode<IdentifierNode>,
							RequiredNode<CloseParenthesisNode>
						>
					>,
					RequiredAndNode<
						RequiredNode<OpenBracketNode>,
						RequiredAndNode<
							RequiredNode<GateFlowNode>,
							RequiredNode<CloseBracketNode>
						>
					>
				>
			>
		>
	>
	{

		public ConditionalStatementNode(int rowStart, int colStart) : base(NodeType.ConditionalStatementNode, rowStart, colStart) { }

		public ConditionalStatementNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ConditionalStatementNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
