using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class MultiLineLocNode : SingleLocNode
	{
		private int _colSpan;
		private int _rowSpan;

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


		public MultiLineLocNode(NodeType type, int rowStart, int colStart) : this(type, rowStart, 0, colStart, 0) { }

		public MultiLineLocNode(NodeType type, int rowStart, int rowSpan, int colStart, int colSpan) : base (type, rowStart, colStart)
		{
			ColSpan = colSpan;
			RowSpan = rowSpan;
		}

	}
}
