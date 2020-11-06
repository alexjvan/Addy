using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class DataStructureDeclarationListNode : ParserNode<
		RequiredOrNode<
			RequiredOrNode<
				NullNode,
				RequiredNode<DataStructureDeclarationListNode>
			>,
			RequiredOrNode<
				RequiredOrNode<
					RequiredNode<ClassDeclarationNode>,
					RequiredNode<GuideDeclarationNode>
				>,
				RequiredNode<SwitchDeclarationNode>
			>
		>
	>
	{

		public DataStructureDeclarationListNode(int rowStart, int colStart) : base(NodeType.DataStructureDeclarationListNode, rowStart, colStart) { }

		public DataStructureDeclarationListNode(int rowStart, int rowSpan, int colStart, int colSpan) : base(NodeType.DataStructureDeclarationListNode, rowStart, rowSpan, colStart, colSpan) { }
	}
}
