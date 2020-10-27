using AddyCompiler.Node;
using AddyCompiler.Parser.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler
{
	public class CompileOutput
	{
		public string input = "";
		public string outputFile = null;
		public bool executed = false;
		public bool compiled = false;
		public TimeSpan[] times = new TimeSpan[5];

		public LexerNode[] lexerOutput;
		public RootNode parserOutput;
		public ParseError[] recognizerOutput;
		public RootNode optimizerOutput;
		public string[] executorOutput;
 }
}
