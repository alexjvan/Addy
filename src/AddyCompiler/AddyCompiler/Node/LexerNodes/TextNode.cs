using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class TextNode : ValueNode<string>
	{
		char _quoteType;
		public char QuoteType
		{
			get
			{
				return _quoteType;
			}
		}

		public TextNode(char quoteType, string value, int row, int col) :  base(NodeType.TextNode, value, row, col)
		{
			_quoteType = quoteType;
		}
	}
}
