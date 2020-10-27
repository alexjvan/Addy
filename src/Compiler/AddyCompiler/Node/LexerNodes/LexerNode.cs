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

        public LexerNode(NodeType type, int row, int col)
        {
			_col = col;
			_row = row;
            _type = type;
        }
    }
}
