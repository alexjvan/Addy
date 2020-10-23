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

				}
				else if(inp.startsWith("compile"))
				{

				}
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
