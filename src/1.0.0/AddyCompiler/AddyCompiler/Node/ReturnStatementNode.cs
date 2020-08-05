using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ReturnStatementNode : ParserNode<
		RequiredAndNode<
			RequiredNode<ReturnKeywordNode>,
			RequiredAndNode<
				RequiredNode<VariableValueNode>,
				RequiredNode<SemiColonNode>
			>
		>	
	>
	{

		public ReturnStatementNode(int rowStart, int colStart) : base(NodeType.ReturnStatementNode, rowStart, colStart) { }

		public ReturnStatementNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ReturnStatementNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
