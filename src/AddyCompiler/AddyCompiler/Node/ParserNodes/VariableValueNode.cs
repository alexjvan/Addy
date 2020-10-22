using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class VariableValueNode : ParserNode<
		RequiredOrNode<
			RequiredNode<TextNode>,
			RequiredOrNode<
				RequiredNode<NumNode>,
				RequiredOrNode<
					RequiredNode<LogicNode>,
					RequiredNode<IdentifierNode>
				>
			>
		>	
	>
	{

		public VariableValueNode(int rowStart, int colStart) : base(NodeType.VariableValueNode, rowStart, colStart) { }

		public VariableValueNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.VariableValueNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
