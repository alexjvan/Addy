using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ClassRepeatableNode : ParserNode<
		RequiredAndNode<
			RequiredNode<ClassRepeatableNode>,
			RequiredOrNode<
				RequiredOrNode<
					RequiredNode<FunctionDeclarationNode>,
					RequiredNode<VariableDeclarationNode>
				>,
				NullNode
			>
		>
	>
	{

		public ClassRepeatableNode(int rowStart, int colStart) : base(NodeType.ClassRepeatableNode, rowStart, colStart) { }

		public ClassRepeatableNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ClassRepeatableNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
