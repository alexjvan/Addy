using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddyCompiler.Node;
using AddyCompiler.Lexer;
using AddyCompiler.Parser;
using AddyCompiler.Recognizer;
using AddyCompiler.Parser.Errors;

namespace AddyCompiler
{
    public class Addy
    {
        public static void Compile(string input, string outfile, bool outputLex = false, bool outputParse = false, bool outputOptimized = false)
        {
            // -- FRONT END
            // Lex
            BuildingNode[] nodes = Lillianne.Lex(input);
			// Parse
			RootNode root = Pal.Parse(nodes);
			// Check
			ParseError[] errorsFound = Rachel.Check(root);

            // -- BACK END
            // OPTIMIZE (control flow analysis)
            //      removed unused variables & methods
			//		remove duplicate calculations where possible
			
			// CONVERT
            //		AST to Linear IR (lowest level code, pure variables and numbers, basic manipulation and storage
            //		IR to x86 code
            //		x64 code to be processed (yasm) into (.o file)
            //		.o file to be processed [linked] (gcc -lc) into executable (.exe file)
        }
    }
}
