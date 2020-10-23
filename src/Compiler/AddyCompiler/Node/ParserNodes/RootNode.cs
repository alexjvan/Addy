using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class RootNode : ParserNode<
		RequiredOrNode<
			RequiredNode<CompilerDeclarationNode>,
			RequiredOrNode<
				RequiredNode<ImportNode>,
				RequiredOrNode<
					RequiredNode<ClassDeclarationNode>,
					RequiredOrNode<
						RequiredNode<GuideDeclarationNode>,
						RequiredOrNode<
							RequiredNode<SwitchDeclarationNode>,
							RequiredOrNode<
								RequiredNode<FunctionDeclarationNode>,
								RequiredOrNode<
									RequiredNode<EntryPointDeclarationNode>,
									RequiredNode<EndlessGenericStatementNode>
								>
							>
						>
					>
				>
			>
		>
	>
	{

		public RootNode() : base(NodeType.RootNode, -1, -1) { }

	}
}
