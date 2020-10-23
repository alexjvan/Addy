using System;
using System.Collections.Generic;
using System.Text;

namespace Terminal
{
	public class InputHandler
	{
		private string _inp;
		private string[] _split;
		private string[] _args;
		public int length;
		private int argStop;
		private Dictionary<string, string[]> _handlers = new Dictionary<string, string[]>();

		public string inp
		{
			get
			{
				return _inp;
			}
			set
			{
				string attemptVal = value;
				while (attemptVal.StartsWith("\t") || attemptVal.StartsWith(" "))
					attemptVal = attemptVal.Substring(1);
				_inp = attemptVal;
				_split = value.Split(" ");
				length = split.Length;
				parseArgs();
				parseHandlers();
			}
		}

		public string[] split
		{
			get
			{
				return _split;
			}
		}
		public string[] args
		{
			get
			{
				return _args;
			}
		}

		public Dictionary<string, string[]> handlers
		{
			get
			{
				return _handlers;
			}
		}

		public InputHandler() : this("") { }

		public InputHandler(string input)
		{
			inp = input;
		}

		public bool equals(string other, bool ignoreArgs = false, bool ignoreHandlers = false)
		{
			if (ignoreArgs)
				return (split[0] == other.Split(" ")[0]);
			if (!ignoreHandlers)
				return (inp == other);
			for(int i = 0; i < argStop; i++)
				if (split[i] != other.Split(" ")[i])
					return false;
			return true;
		}

		public bool equalsIgnoreCase(string other, bool ignoreArgs = false, bool ignoreHandlers = false)
		{
			if (ignoreArgs)
				return (split[0].ToLower() == other.Split(" ")[0].ToLower());
			if (!ignoreHandlers)
				return (inp.ToLower() == other.ToLower());
			for (int i = 0; i < argStop; i++)
				if (split[i].ToLower() != other.Split(" ")[i].ToLower())
					return false;
			return true;
		}
		
		public bool startsWith(string other)
		{
			return (_inp.StartsWith(other));
		}

		// parse the arguments to pass to the terminal
		private void parseArgs()
		{
			List<string> args = new List<string>();
			// start traversal - stop at one that starts with '-'
			for (int i = 0; i < split.Length; i++)
			{
				string cur = split[i];
				if (cur.StartsWith("-"))
				{
					argStop = i - 1;
					break;
				}
				else
					args.Add(cur);
			}
			// set the var
			_args = args.ToArray();
		}

		// parse the '-o output' handlers
		private void parseHandlers()
		{
			// no need in starting a traversal if its already at the end
			if (argStop == split.Length)
				return;
			Dictionary<string, string[]> handles = new Dictionary<string, string[]>();
			string curHandle = "";
			List<string> curArgs = new List<string>();
			// traverse
			for (int i = argStop; i < split.Length; i++)
			{
				string cur = split[i];
				if (cur.StartsWith("-"))
				{
					if (curHandle != "")
						handles.Add(curHandle, curArgs.ToArray());
					curHandle = cur;
				}
				else
					curArgs.Add(cur);
			}
			// catch overflow
			if (curHandle != "")
				handles.Add(curHandle, curArgs.ToArray());
			// set handlers var
			_handlers = handles;
		}

		// Make inp = string easier
		public static implicit operator InputHandler(string other)
		{
			return new InputHandler(other);
		}

		public static bool operator ==(InputHandler one, string two) {
			return one.equals(two);
		}

		// Easy equating
		public static bool operator !=(InputHandler one, string two)
		{
			return !(one == two);
		}

	}
}
