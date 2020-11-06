using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
    public abstract class LexerNode
	{
		private int _col;
		private int _row;
		private int _colSpan;
		private int _rowSpan;
		private NodeType _type;

		protected string _stringVal = "";

		public int Col
		{
			get
			{
				return _col;
			}
		}

		public int Row
		{
			get
			{
				return _row;
			}
		}

		public int ColSpan
		{
			get
			{
				return _colSpan;
			}
			set
			{
				_colSpan = value;
			}
		}

		public int RowSpan
		{
			get
			{
				return _rowSpan;
			}
			set
			{
				_rowSpan = value;
			}
		}

		public NodeType Type
        {
            get
            {
                return _type;
            }
        }

		public string RawVal
		{
			get
			{
				return _stringVal;
			}
		}

		public int Length
		{
			get
			{
				return _stringVal.Length;
			}
		}

        public LexerNode(NodeType type, int row, int col) : this(type, row, 0, col, 0) { }

		public LexerNode(NodeType type, int row, int rowSpan, int col, int colSpan)
		{
			_col = col;
			_row = row;
			_colSpan = colSpan;
			_rowSpan = rowSpan;
			_type = type;
		}
    }
}
