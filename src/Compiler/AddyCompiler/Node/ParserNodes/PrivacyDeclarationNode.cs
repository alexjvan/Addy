using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class PrivacyDeclarationNode : ParserNode<
		RequiredOrNode<
			RequiredNode<PublicKeywordNode>,
			RequiredOrNode<
				RequiredNode<FriendlyKeywordNode>,
				RequiredNode<PrivateKeywordNode>
			>
		>	
	>
	{

		public PrivacyDeclarationNode(int rowStart, int colStart) : base(NodeType.PrivacyDeclarationNode, rowStart, colStart) { }

		public PrivacyDeclarationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.PrivacyDeclarationNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
