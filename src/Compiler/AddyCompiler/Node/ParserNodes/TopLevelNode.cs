using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class TopLevelNode : ParserNode<
		// ((class, guide, switch)
		// (function)
		// (statements))*
		RequiredOrNode<
			RequiredOrNode<
				RequiredNode<DataStructureDeclarationListNode>,
				RequiredNode<FunctionDeclarationListNode>
			>,
			RequiredOrNode<
				RequiredNode<EndlessGenericStatementNode>,
				RequiredOrNode<
					NullNode,
					RequiredNode<TopLevelNode>	
				>
			>
		>
	>
	{

		public TopLevelNode(int rowStart, int colStart) : base(NodeType.TopLevelNode, rowStart, colStart) { }

		public TopLevelNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.TopLevelNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
