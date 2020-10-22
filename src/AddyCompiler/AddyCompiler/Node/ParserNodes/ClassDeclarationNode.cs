using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ClassDeclarationNode : ParserNode<
		// 'public' class ex {_}
		RequiredAndNode<
			// w/ Privacy
			RequiredOrNode<
				RequiredNode<PrivacyDeclarationNode>,
				NullNode
			>,
			RequiredAndNode<
				RequiredNode<ClassKeywordNode>,
				RequiredAndNode<
					RequiredNode<IdentifierNode>,
					RequiredNode<ClassInternalsNode>
				>
			>
		>
	>
	{

		public ClassDeclarationNode(int rowStart, int colStart) : base(NodeType.ClassDeclarationNode, rowStart, colStart) { }

		public ClassDeclarationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base (NodeType.ClassDeclarationNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
