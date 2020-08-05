using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ClassInternalsNode : ParserNode<
		RequiredAndNode<
			RequiredNode<OpenBracketNode>,
			RequiredAndNode<
				RequiredNode<ClassRepeatableNode>,
				RequiredNode<CloseBracketNode>
			>
		>	
	>
	{

		public ClassInternalsNode(int rowStart, int colStart) : base(NodeType.ClassInternalsNode, rowStart, colStart) { }

		public ClassInternalsNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ClassInternalsNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
