using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class EntryPointDeclarationNode : ParserNode<
		// global public entry(text[] args) {_}
		RequiredAndNode<
			RequiredNode<ScopeDeclarationNode>,
			RequiredAndNode<
				RequiredNode<PrivacyDeclarationNode>,
				RequiredAndNode<
					RequiredNode<EntryKeywordNode>,
					RequiredAndNode<
						RequiredNode<OpenParenthesisNode>,
						RequiredAndNode<
							RequiredAndNode<
								RequiredNode<TextKeywordNode>,
								RequiredAndNode<
									RequiredNode<OpenBraceNode>,
									RequiredAndNode<
										RequiredNode<CloseBraceNode>,
										RequiredNode<IdentifierNode>
									>
								>
							>,
							RequiredAndNode<
								RequiredNode<CloseParenthesisNode>,
								RequiredNode<CodeBodyNode>
							>
						>
					>
				>
			>
		>	
	>
	{

		public EntryPointDeclarationNode(int rowStart, int colStart) : base(NodeType.EntryPointDeclarationNode, rowStart, colStart) { }

		public EntryPointDeclarationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.EntryPointDeclarationNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
