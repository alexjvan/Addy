using AddyCompiler;
using AddyCompiler.Node;
using System;
using System.Collections.Generic;
using System.IO;

namespace Terminal
{
	public class Terminal
	{
		private static TerminalSettings settings = new TerminalSettings();
		private static string[] curDir = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length).Split("\\");

		static void Main(string[] args)
		{
			getSettings();
			writeIntro();
			gameLoop();
			Console.ReadLine();
		}

		static void getSettings()
		{
			using(StreamReader reader = new StreamReader("settings.txt"))
			{
				settings.version = reader.ReadLine().Substring(9);
				settings.outputInput = bool.Parse(reader.ReadLine().Substring(13));
				settings.outputOutFile = bool.Parse(reader.ReadLine().Substring(18));
				settings.outputLex = bool.Parse(reader.ReadLine().Substring(11));
				settings.outputParse = bool.Parse(reader.ReadLine().Substring(13));
				settings.outputTimes = bool.Parse(reader.ReadLine().Substring(13));
			}
		}

		static void writeIntro()
		{
			Console.WriteLine($"Welcome to the Addy Programming language. Version: {settings.version}");
			Console.WriteLine("Solely designed and developed by Alex Van Matre. (http://www.alexvanmatre.com)");
			Console.WriteLine("The Addy Compiler and the Addy Terminal are protected by the apache 2.0 license.");
			Console.WriteLine("Please type .help for help.");
		}

		static void helpPage()
		{

		}

		static void gameLoop()
		{
			InputHandler inp = new InputHandler();
			while(true)
			{
				Console.WriteLine("\n" + printDir());
				Console.Write(" >> ");
				inp = Console.ReadLine();

				if (inp == "exit")
					return;
				else if (inp == "help")
					helpPage();
				else if (inp.startsWith("cd"))
				{
					if (inp.split.Length == 1)
						Console.WriteLine(printDir());
					else
					{
						string[] oldDir = curDir;
						string[] manipulations = inp.inp.Substring(3).Split("/");
						for(int i = 0; i < manipulations.Length; i++)
						{
							if (manipulations[i] == "")
								continue;
							bool success = moveDir(manipulations[i]);
							if(!success)
							{
								Console.WriteLine($"{manipulations[i]} is not a folder in {printDir()}.");
								Console.Write("Do you want to keep manipulations to the directory up to that folder? (y/n): ");
								string line = Console.ReadLine();
								if(!line.ToLower().StartsWith('y'))
									curDir = oldDir;
								break;
							}
						}
					}
				}
				else if(inp.startsWith("ls"))
				{
					if(inp.args.Length == 1)
						printContents(printDir());
					else
					{
						string[] saveDir = curDir;
						string[] manipulations = inp.inp.Substring(3).Split("/");
						for (int i = 0; i < manipulations.Length; i++)
						{
							if (manipulations[i] == "")
								continue;
							bool success = moveDir(manipulations[i]);
							if (!success)
							{
								Console.WriteLine($"{manipulations[i]} is not a folder in {printDir()}.");
								break;
							}
						}
						printContents(printDir());
						curDir = saveDir;
					}
				}
				else if(inp.startsWith("run"))
				{
					if (inp.args.Length == 1)
					{
						// run information
					}
					else if(inp.args.Length == 2)
					{
						// run
						if(File.Exists(printDir() + inp.args[1]))
						{
							if(inp.args[1].EndsWith(".addy"))
							{
								string contents = readLines(inp.args[1]);
								CompileOutput output = Addy.Compile(contents);
								if(settings.outputLex)
								{
									printLex(output.input.Length, output.lexerOutput, output.times[0]);
								}
							}
							else
							{
								// Not a valid file extension
								continue;
							}
						}
						else
						{
							// Not a valid file
							continue;
						}
					}
					else
					{

					}
				}
				else if(inp.startsWith("compile"))
				{
					if(inp.args.Length == 1)
					{
						// compile
					}
					else if (inp.args.Length == 2)
					{
						// compile
					}
					else
					{

					}
				}
			}
		}

		static string readLines(string file)
		{
			string[] lines = File.ReadAllLines(printDir() + file);
			string asString = "";
			foreach (string line in lines)
				asString += line + "\n";
			return asString;
		}

		static void printLex(int initialLength, LexerNode[] nodes, TimeSpan lexTime)
		{
			string timeToPrint = ((int)lexTime.TotalSeconds > 0) ? lexTime.TotalSeconds+"" : lexTime.TotalMilliseconds+"m";
			Console.WriteLine("-------------------------------------------------------------------------------------------------");
			Console.WriteLine($"Lexer Output\t\tInput Length: {initialLength}\tCalculated Nodes: {nodes.Length}\tTook: {timeToPrint}s");
			Console.WriteLine("-------------------------------------------------------------------------------------------------");
			Console.WriteLine("NodeType\t\t\tRow\tCol\tString Value");
			Console.WriteLine("-------------------------------------------------------------------------------------------------");
			int typeLength = 32;
			int rowLength = 8;
			int colLength = 8;
			int rawLength = 70;
			foreach (LexerNode node in nodes)
			{
				string typeString = node.Type.ToString();
				Console.Write(typeString);
				for (int left = typeLength - typeString.Length; left > 0; left--)
					Console.Write(" ");
				Console.Write(node.Row);
				for (int left = rowLength - node.Row.ToString().Length; left > 0; left--)
					Console.Write(" ");
				Console.Write(node.Col);
				for (int left = colLength - node.Col.ToString().Length; left > 0; left--)
					Console.Write(" ");
				string printedRaw = node.RawVal;
				if(printedRaw.Length > rawLength)
				{
					while (printedRaw.Length > rawLength)
					{
						Console.Write(printedRaw.Substring(0, rawLength));
						printedRaw = printedRaw.Substring(rawLength);
						Console.WriteLine();
						for (int left = typeLength+rowLength+colLength - 1; left > 0; left--)
							Console.Write(" ");
					}
					Console.Write(printedRaw);
				}
				else
					Console.Write(node.RawVal);
				Console.WriteLine();
			}
		}



		static void printContents(string dir)
		{
			string[] folders = Directory.GetDirectories(dir);
			string[] files = Directory.GetFiles(dir);
			string[] mixed = new string[folders.Length + files.Length];
			int curFol = 0;
			int curFil = 0;
			for(int i = 0; i < mixed.Length; i++)
			{
				if(curFol == folders.Length)
				{
					mixed[i] = getLast(files[curFil]);
					curFil++;
				}
				else if(curFil == files.Length)
				{
					mixed[i] = getLast(folders[curFol]) + "/";
					curFol++;
				}
				// if files are greater than folders
				else if(getLast(files[curFil]).CompareTo(getLast(folders[curFol])) < 0)
				{
					mixed[i] = getLast(files[curFil]);
					curFil++;
				}
				else
				{
					mixed[i] = getLast(folders[curFol]) + "/";
					curFol++;
				}
			}
			foreach (string item in mixed)
				Console.WriteLine(item);
		}

		static bool moveDir(string toChange)
		{
			if(toChange == "..")
			{
				string[] newDir = new string[curDir.Length - 1];
				for(int i = 0; i < curDir.Length - 1; i++)
					newDir[i] = curDir[i];
				curDir = newDir;
				return true;
			}
			string tryDir = printDir() + toChange+"/";
			if (Directory.Exists(tryDir))
			{
				string[] newDir = new string[curDir.Length + 1];
				for (int i = 0; i < curDir.Length; i++)
					newDir[i] = curDir[i];
				newDir[curDir.Length] = toChange;
				curDir = newDir;
				return true;
			}
			else
				return false;
		}

		static string getLast(string dir)
		{
			string[] split = dir.Split("/");
			return split[split.Length - 1];
		}

		static string printDir()
		{
			string dir = "";
			for(int i = 0; i < curDir.Length; i++)
				dir += curDir[i] + "/";
			return dir;
		}

	}
}
