using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class SwitchDeclarationNode : ParserNode<
		RequiredAndNode<
			RequiredOrNode<
				RequiredNode<PrivacyDeclarationNode>,
				NullNode
			>,
			RequiredAndNode<
				RequiredNode<SwitchKeywordNode>,
				RequiredAndNode<
					RequiredNode<OpenBracketNode>,
					RequiredAndNode<
						RequiredNode<IdentifierListNode>,
						RequiredNode<CloseBracketNode>
					>
				>
			>
		>	
	>
	{

		public SwitchDeclarationNode(int rowStart, int colStart) : base(NodeType.SwitchDeclarationNode, rowStart, colStart) { }

		public SwitchDeclarationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.SwitchDeclarationNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
