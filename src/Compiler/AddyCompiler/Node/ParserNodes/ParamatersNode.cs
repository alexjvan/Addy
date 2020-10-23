using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ParamatersNode : ParserNode<
		RequiredAndNode<
			RequiredNode<OpenParenthesisNode>,
			RequiredAndNode<
				RequiredNode<ParamatersListNode>,
				RequiredNode<CloseParenthesisNode>
			>
		>	
	>
	{

		public ParamatersNode(int rowStart, int colStart) : base(NodeType.ParamatersNode, rowStart, colStart) { }

		public ParamatersNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ParamatersNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
