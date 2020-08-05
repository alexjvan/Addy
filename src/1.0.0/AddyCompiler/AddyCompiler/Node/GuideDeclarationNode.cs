using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class GuideDeclarationNode : ParserNode<
		RequiredOrNode<
			// guide ex {_}
			RequiredAndNode<
				// No privacy
				RequiredNode<ClassKeywordNode>,
				RequiredAndNode<
					RequiredNode<IdentifierNode>,
					RequiredNode<CodeBodyNode>
				>
			>,
			// public guide ex {_}
			RequiredAndNode<
				// w/ Privacy
				RequiredNode<PrivacyDeclarationNode>,
				RequiredAndNode<
					RequiredNode<ClassKeywordNode>,
					RequiredAndNode<
						RequiredNode<IdentifierNode>,
						RequiredNode<CodeBodyNode>
					>
				>
			>
		>
	>
	{

		public GuideDeclarationNode(int rowStart, int colStart) : base(NodeType.GuideDeclarationNode, rowStart, colStart) { }

		public GuideDeclarationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.GuideDeclarationNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
