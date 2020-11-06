using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class FunctionDeclarationListNode : ParserNode<
		RequiredOrNode<
			RequiredOrNode<
				NullNode,
				RequiredNode<FunctionDeclarationListNode>
			>,
			RequiredOrNode<
				RequiredNode<FunctionDeclarationNode>,
				RequiredNode<EntryPointDeclarationNode>
			>
		>
	>
	{

		public FunctionDeclarationListNode(int rowStart, int colStart) : base(NodeType.FunctionDeclarationListNode, rowStart, colStart) { }

		public FunctionDeclarationListNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.FunctionDeclarationListNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
