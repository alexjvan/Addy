using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class ParamatersListNode : ParserNode<
		RequiredOrNode<
			RequiredOrNode<
				RequiredAndNode<
					RequiredNode<VariableKeywordNode>,
					RequiredNode<IdentifierNode>
				>,
				RequiredAndNode<
					RequiredAndNode<
						RequiredNode<VariableKeywordNode>,
						RequiredNode<IdentifierNode>
					>,
					RequiredAndNode<
						RequiredNode<SemiColonNode>,
						RequiredNode<ParamatersListNode>
					>
				>
			>,
			NullNode
		>	
	>
	{

		public ParamatersListNode(int rowStart, int colStart) : base(NodeType.ParamatersListNode, rowStart, colStart) { }

		public ParamatersListNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.ParamatersListNode, rowStart, rowSpan, colStart, colSpan) { }

	}
}
