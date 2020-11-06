using AddyCompiler.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Parser.Errors
{
	public class NotExpectedNodeError : ParseError
	{
		private NodeType _expected;
		private LexerNode _recieved;

		public NodeType expected 
		{
			get
			{
				return _expected;
			}
		}

		public LexerNode recieved
		{
			get
			{
				return _recieved;
			}
		}

		public NotExpectedNodeError(NodeType expected, LexerNode recieved) : base(ErrorType.NotExpectedNode) {
			_expected = expected;
			_recieved = recieved;
		}
	}
}
