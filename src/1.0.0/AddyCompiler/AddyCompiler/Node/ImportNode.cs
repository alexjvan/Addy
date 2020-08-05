using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ImportNode : ParserNode<
		RequiredOrNode<
			// import "ex";
			RequiredAndNode<
				RequiredNode<ImportKeywordNode>,
				RequiredAndNode<
					RequiredNode<TextNode>,
					RequiredNode<SemiColonNode>
				>
			>,
			// import "ex" as ex;
			RequiredAndNode<
				RequiredNode<ImportKeywordNode>,
				RequiredAndNode<
					RequiredNode<TextNode>,
					RequiredAndNode<
						RequiredNode<AsKeywordNode>, 
						RequiredAndNode<
							RequiredNode<IdentifierNode>,
							RequiredNode<SemiColonNode>
						>
					>
				>
			>
		>
	>
	{
		public ImportNode(int rowStart, int colStart) : base(NodeType.ImportDeclaration, rowStart, colStart) { }
		public ImportNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ImportDeclaration, rowStart, rowSpan, colStart, colSpan) { }
	}
}
