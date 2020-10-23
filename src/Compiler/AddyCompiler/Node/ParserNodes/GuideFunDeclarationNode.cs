using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class GuideFunDeclarationNode : ParserNode<
		// 'local' 'public' fun ex(_);
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
							RequiredNode<SemiColonNode>
						>
					>
				>
			>
		>
	>
	{

		public GuideFunDeclarationNode(int rowStart, int colStart) : base(NodeType.GuideFunctionDeclarationNode, rowStart, colStart) { }

		public GuideFunDeclarationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.GuideFunctionDeclarationNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
