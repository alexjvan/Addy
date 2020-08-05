using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class VariableKeywordNode : ParserNode<
		RequiredOrNode<
			RequiredOrNode<
				RequiredNode<TextKeywordNode>,
				RequiredNode<NumKeywordNode>
			>,
			RequiredOrNode<
				RequiredNode<LogicKeywordNode>,
				RequiredNode<IdentifierNode>
			>
		>
	>
	{

		public VariableKeywordNode(int rowStart, int colStart) : base(NodeType.VariableKeywordNode, rowStart, colStart) { }

		public VariableKeywordNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.VariableKeywordNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
