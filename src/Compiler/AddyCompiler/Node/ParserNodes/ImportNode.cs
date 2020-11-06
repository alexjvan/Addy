using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ImportNode : ParserNode<
		// import "ex" 'as ex';
		RequiredAndNode<
			RequiredNode<ImportKeywordNode>,
			RequiredAndNode<
				RequiredNode<TextNode>,
				RequiredAndNode<
					RequiredOrNode<
						NullNode,
						RequiredAndNode<
							RequiredNode<AsKeywordNode>,
							RequiredNode<IdentifierNode>
						>
					>,
					RequiredNode<SemiColonNode>
				>
			>
		>
	>
	{
		public ImportNode(int rowStart, int colStart) : base(NodeType.ImportDeclarationNode, rowStart, colStart) { }
		public ImportNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ImportDeclarationNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
