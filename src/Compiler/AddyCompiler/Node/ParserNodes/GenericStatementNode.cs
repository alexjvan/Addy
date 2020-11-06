using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class GenericStatementNode : ParserNode<
		// if, switch
		// do, for, while
		// text t = "";
		// n++;
		// wow()
		// return 12;
		RequiredOrNode<
			RequiredNode<ConditionalStatementNode>,
			RequiredOrNode<
				RequiredNode<ConditionalLoopNode>,
				RequiredOrNode<
					RequiredNode<VariableDeclarationNode>,
					RequiredOrNode<
						RequiredNode<VariableManipulationNode>,
						RequiredOrNode<
							RequiredNode<FunctionCallNode>,
							RequiredNode<ReturnStatementNode>
						>
					>
				>
			>
		>
	>
	{

		public GenericStatementNode(int rowStart, int colStart) : base(NodeType.GenericStatementNode, rowStart, colStart) { }

		public GenericStatementNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.GenericStatementNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
