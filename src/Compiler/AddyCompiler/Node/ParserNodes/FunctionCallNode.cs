using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class FunctionCallNode : ParserNode<
		// 'file.''class.'fun(args);
		RequiredAndNode<
			RequiredAndNode<
				RequiredOrNode<
					RequiredAndNode<
						RequiredOrNode<
							RequiredAndNode<
								RequiredNode<IdentifierNode>,
								RequiredNode<PeriodNode>
							>,
							NullNode
						>,
						RequiredAndNode<
							RequiredNode<IdentifierNode>,
							RequiredNode<PeriodNode>
						>
					>,
					NullNode
				>,
				RequiredNode<IdentifierNode>
			>,
			RequiredAndNode<
				RequiredNode<ArgumentsNode>,
				RequiredNode<SemiColonNode>
			>
		>	
	>
	{

		public FunctionCallNode(int rowStart, int colStart) : base(NodeType.FunctionCallNode, rowStart, colStart) { }

		public FunctionCallNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.FunctionCallNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
