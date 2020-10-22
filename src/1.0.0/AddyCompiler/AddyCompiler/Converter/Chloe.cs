using AddyCompiler.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Converter
{
	public class Chloe
	{
		public static bool Convert(RootNode root, string outputFile)
		{
			// Todo
			string[] ir = ToIR(root);

			string[] sixtyfour = To64(ir);

			bool toexe = ToEXE(sixtyfour, outputFile);

			return toexe;
		}

		private static string[] ToIR(RootNode root)
		{
			List<string> lines = new List<string>();


			return lines.ToArray();
		}

		private static string[] To64(string[] ir)
		{
			List<string> lines = new List<string>();



			return lines.ToArray();
		}

		private static bool ToEXE(string[] sixfour, string outputFile)
		{
			// x64 code to .o file
			// link .o to .exe

			// TODO CHANGE
			return true;
		}

	}
}
