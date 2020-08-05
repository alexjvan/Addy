using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class CompilerDeclarationNode : ValueNode<string>
	{

		public CompilerDeclarationNode(string declaration, int row, int col) : base(NodeType.CompilerDeclarationNode, declaration, row, col) { }

	}
}
