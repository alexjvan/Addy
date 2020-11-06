using AddyCompiler.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Parser.Errors
{
	public class CouldntInsertNodeError : ParseError
	{
		private LexerNode _tried;
		private LexerNode _into;

		public LexerNode tried
		{
			get
			{
				return _tried;
			}
		}

		public LexerNode into
		{
			get
			{
				return _into;
			}
		}

		public CouldntInsertNodeError(LexerNode tried, LexerNode into) : base(ErrorType.CouldntInsertNode)
		{
			_tried = tried;
			_into = into;
		}
	}
}
