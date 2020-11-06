using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class RootNode : ParserNode<
		// Not Required - ImportNode
		// (class, guide, switch)*
		// (function)*
		// (statements)*
		RequiredOrNode<
			RequiredNode<ImportNode>,
			RequiredNode<TopLevelNode>
		>
	>
	{

		public RootNode() : base(NodeType.RootNode, -1, -1) { }

	}
}
