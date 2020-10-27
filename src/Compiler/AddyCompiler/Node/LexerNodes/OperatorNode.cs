using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public abstract class OperatorNode : PunctuationNode
	{
		private LexerNode _left;
		private LexerNode _right;

		public LexerNode LeftNode
		{
			get
			{
				return _left;
			}
			set
			{
				_left = value;
			}
		}

		public LexerNode RightNode
		{
			get
			{
				return _right;
			}
			set
			{
				_right = value;
			}
		}

		public OperatorNode(NodeType type, char val, int row, int col) : base(type, val, row, col) { }
	}
}
