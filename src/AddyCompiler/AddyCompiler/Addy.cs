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
			RootNode root = Bobbi.Parse(nodes);
			// Check
			ParseError[] errorsFound = Martha.Check(root);

            // -- MIDDLE END
            // OPTIMIZE
            //      removed unused variables & methods
			//		remove duplicate calculations where possible

            // -- BACK END
            // Create File
        }
    }
}
