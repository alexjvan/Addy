using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node.Generics
{
	public class ParserNode<T> : ParserNode where T : ReqNode
	{
		public new T Required
		{
			get
			{
				return (T)_required;
			}
			set
			{
				_required = value;
			}
		}

		public ParserNode(NodeType type, int rowStart, int colStart) : this(type, rowStart, 0, colStart, 0) { }

		public ParserNode(NodeType type, int rowStart, int rowSpan, int colStart, int colSpan) : base(type, rowStart, rowSpan, colStart, colSpan) { }

	}
}
