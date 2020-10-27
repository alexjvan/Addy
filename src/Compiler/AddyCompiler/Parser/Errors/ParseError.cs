using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Parser.Errors
{
	public abstract class ParseError
	{
		private ErrorType _type;

		public ErrorType Type
		{
			get
			{
				return _type;
			}
		}

		public ParseError(ErrorType type)
		{
			_type = type;
		}
	}
}
