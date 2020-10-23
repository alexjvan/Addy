using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ScopeDeclarationNode : ParserNode<
		RequiredOrNode<
			RequiredNode<GlobalKeywordNode>,
			RequiredNode<LocalKeywordNode>
		>	
	>
	{

		public ScopeDeclarationNode(int rowStart, int colStart) : base(NodeType.ScopeDeclarationNode, rowStart, colStart) { }

		public ScopeDeclarationNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ScopeDeclarationNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
