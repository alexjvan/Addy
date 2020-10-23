using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class VariableDeclarationNode : ParserNode<
		// 'global' 'public' text ex;
		// 'global' 'public' text ex = "example";
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
					RequiredNode<VariableKeywordNode>,
					RequiredAndNode<
						RequiredNode<IdentifierNode>,
						RequiredOrNode<
							RequiredNode<SemiColonNode>,
							RequiredAndNode<
								RequiredNode<EqualsNode>,
								RequiredAndNode<
									RequiredNode<VariableValueNode>,
									RequiredNode<SemiColonNode>
								>
							>
						>
					>
				>
			>
		>	
	>
	{

		public VariableDeclarationNode(int rowStart, int colStart) : base(NodeType.VariableDeclarationNode, rowStart, colStart) { }

		public VariableDeclarationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.VariableDeclarationNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
