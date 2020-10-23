using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class FunctionDeclarationNode : ParserNode<
		// 'local' 'public' fun ex(_) {_}
		RequiredAndNode<
			RequiredOrNode<
				RequiredNode<ScopeDeclarationNode>,
				NullNode
			>,
			RequiredAndNode<
				RequiredOrNode<
					RequiredNode<PrivacyDeclarationNode>,
					NullNode
				>,
				RequiredAndNode<
					RequiredNode<FunctionKeywordNode>,
					RequiredAndNode<
						RequiredNode<IdentifierNode>,
						RequiredAndNode<
							RequiredNode<ParamatersNode>,
							RequiredNode<CodeBodyNode>
						>
					>
				>
			>
		>
	>
	{

		public FunctionDeclarationNode(int rowStart, int colStart) : base(NodeType.FunctionDeclarationNode, rowStart, colStart) { }

		public FunctionDeclarationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.FunctionDeclarationNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
