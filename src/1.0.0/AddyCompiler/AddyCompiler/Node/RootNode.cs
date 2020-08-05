using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class RootNode : ParserNode<RequiredOrNode<CompilerDeclarationNode, RequiredOrNode<ImportNode, RequiredOrNode<ClassDeclarationNode, RequiredOrNode<SwitchDeclarationNode, RequiredOrNode<GuideDeclarationNode, RequiredOrNode<FunctionDeclarationNode, GenericStatementNode>>>>>>>
	{

		public RootNode() : base(NodeType.RootNode, -1, -1) { }

	}
}
