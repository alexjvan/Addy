using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public abstract class SingleLocNode : BuildingNode
	{
		private int _row;
		private int _col;

		public int Row
		{
			get
			{
				return _row;
			}
		}

		public int Col
		{
			get
			{
				return _col;
			}
		}

		public SingleLocNode(NodeType type, int row, int col) : base(type)
		{
			_row = row;
			_col = col;
		}

	}
}
