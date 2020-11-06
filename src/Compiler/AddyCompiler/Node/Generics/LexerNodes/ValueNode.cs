using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node.Generics
{
	public abstract class ValueNode<T> : LexerNode
	{
		private T _val;

		public T Value
		{
			get
			{
				return _val;
			}
		}

		public ValueNode(NodeType type, T value, int row, int col) : base(type, row, 1, col, value.ToString().Length)
		{
			_val = value;
			_stringVal = value.ToString();
		}
	}
}
