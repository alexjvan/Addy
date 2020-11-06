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
using AddyCompiler.Optimizer;
using AddyCompiler.Converter;
using AddyCompiler.Executor;
using System.Diagnostics;

namespace AddyCompiler
{
    public class Addy
    {
        public static CompileOutput Compile(string input, string outfile = null)
        {
            CompileOutput co = new CompileOutput();
            co.input = input;
            co.outputFile = outfile;
            Stopwatch stopWatch = Stopwatch.StartNew();
            // ----- FRONT END -----
            // LEX
            //      Convert string input into basic tokens
            //      Nothing more than variables to hold the absolute basics
            LexerNode[] nodes = Lillianne.Lex(input);
            co.lexerOutput = nodes;
            co.times[0] = stopWatch.Elapsed;
            stopWatch.Restart();

            // PARSE
            //      Convert tokens into nodes
            //      Build AST
            ParseError[] compileErrors;
			RootNode root = Pal.Parse(nodes, out compileErrors);
            co.parserOutput = root;
            co.times[1] = stopWatch.Elapsed;
            stopWatch.Restart();

            // RECOGNIZE
            //      Make sure everything has everything that it needs to have (all reqands and reqors are good)
            ParseError[] errorsFound = Rachel.Check(root);

            // Combine the two error sections
            ParseError[] collectiveErrors = new ParseError[compileErrors.Length + errorsFound.Length];
            for (int i = 0; i < compileErrors.Length; i++)
                collectiveErrors[i] = compileErrors[i];
            for (int i = 0; i < errorsFound.Length; i++)
                collectiveErrors[i + compileErrors.Length] = errorsFound[i];

            co.recognizerOutput = collectiveErrors;
            co.times[2] = stopWatch.Elapsed;
            stopWatch.Restart();

            // STOP
            //      If there are errors in the program - return with those errors
            //      No need to continue and optimize, compile/execute incorrect code
            if (errorsFound.Length != 0)
                return co;

            // ----- BACK END -----
            // OPTIMIZE (control flow analysis)
            //      removed unused variables & methods
            //		remove duplicate calculations where possible
            RootNode optimized = Olivia.Optimize(root);
            co.optimizerOutput = optimized;
            co.times[3] = stopWatch.Elapsed;
            stopWatch.Restart();

            if (outfile == null)
			{
                // EXECUTE
                //      In shell, execute the given code to give the output
                string[] output = Emma.Execute(optimized);
                co.executed = true;
                co.executorOutput = output;
                co.times[4] = stopWatch.Elapsed;
                stopWatch.Restart();
            } 
            else
			{
                // CONVERT
                //		AST to Linear IR (lowest level code, pure variables and numbers, basic manipulation and storage
                //		IR to x86 code
                //		x64 code to be processed (yasm) into (.o file)
                //		.o file to be processed [linked] (gcc -lc) into executable (.exe file)
                bool successful = Chloe.Convert(optimized, outfile);
                co.compiled = true;
                co.times[4] = stopWatch.Elapsed;
                stopWatch.Restart();
            }

            return co;
        }
    }
}
