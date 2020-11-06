using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public abstract class ParserNode : LexerNode
	{
		protected ReqNode _required;

		public ReqNode Required
		{
			get
			{
				return _required;
			}
			set
			{
				_required = value;
			}
		}

		public ParserNode(NodeType type, int rowStart, int colStart) : this(type, rowStart, 0, colStart, 0) { }

		public ParserNode(NodeType type, int rowStart, int rowSpan, int colStart, int colSpan) : base(type, rowStart, rowSpan, colStart, colSpan) { }

		public bool hasRequired()
		{
			return _required.hasRequired();
		}

	}
}
