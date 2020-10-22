using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class CodeBodyNode : ParserNode<
		// { (StatementNode)* }
		RequiredAndNode<
			RequiredNode<OpenBracketNode>,
			RequiredAndNode<
				RequiredNode<EndlessGenericStatementNode>,
				RequiredNode<CloseBracketNode>
			>
		>
	>
	{

		public CodeBodyNode(int rowStart, int colStart) : base(NodeType.CodeBodyNode, rowStart, colStart) { }

		public CodeBodyNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.CodeBodyNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
