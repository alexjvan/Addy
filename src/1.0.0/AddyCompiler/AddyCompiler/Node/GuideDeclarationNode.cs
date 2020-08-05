using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class GuideDeclarationNode : ParserNode<
		// 'public' guide ex {_}
		RequiredAndNode<
			RequiredOrNode<
				RequiredNode<PrivacyDeclarationNode>,
				NullNode
			>,
			RequiredAndNode<
				RequiredNode<GuideKeywordNode>,
				RequiredAndNode<
					RequiredNode<IdentifierNode>,
					RequiredNode<ClassInternalsNode>
				>
			>
		>
	>
	{

		public GuideDeclarationNode(int rowStart, int colStart) : base(NodeType.GuideDeclarationNode, rowStart, colStart) { }

		public GuideDeclarationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.GuideDeclarationNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
