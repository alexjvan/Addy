using AddyCompiler.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Lexer
{
    public class Lillianne
    {
        public static BuildingNode[] Lex(string input)
        {
            List<BuildingNode> nodes = new List<BuildingNode>();

            int row = 1;
            int col = 1;

            string building = "";

            for(int i = 0; i < input.Length; i++)
            {
                char cur = input[i];

                switch(cur)
                {
                    // literals
                    case '\n':
						checkBuild(nodes, building, row, col);
						row++;
                        col = 0;
                        break;
                    case '\t':
						// only increase col by three because the next will increase it by one more
                        col += 3;
                        break;
					case '#':
						// multiline comment
						if(input[i + 1] == '-')
						{
							bool done = false;
							i += 2;
							cur = input[i];
							while(!done)
							{
								while (cur != '-')
								{
									i++;
									cur = input[i];
								}
								i++;
								cur = input[i];
								if (cur == '#')
									done = true;
							}
						}
						// singleline comment
						else
						{
							while (cur != '\n')
							{
								i++;
								cur = input[i];
							}
						}
						break;

					// operators
					case '+':
						checkBuild(nodes, building, row, col);
						nodes.Add(new AdditionNode(row, col));
						break;
					case '-':
						checkBuild(nodes, building, row, col);
						nodes.Add(new SubtractionNode(row, col));
						break;
					case '*':
						checkBuild(nodes, building, row, col);
						nodes.Add(new MultiplicationNode(row, col));
						break;
					case '/':
						checkBuild(nodes, building, row, col);
						nodes.Add(new DivisionNode(row, col));
						break;
					// punctuation
					case '.':
						checkBuild(nodes, building, row, col);
						nodes.Add(new PeriodNode(row, col));
						break;
					case ',':
						checkBuild(nodes, building, row, col);
						nodes.Add(new CommaNode(row, col));
						break;
					case ':':
						checkBuild(nodes, building, row, col);
						nodes.Add(new ColonNode(row, col));
						break;
					case ';':
						checkBuild(nodes, building, row, col);
						nodes.Add(new SemiColonNode(row, col));
						break;
					case '?':
						checkBuild(nodes, building, row, col);
						nodes.Add(new QuestionNode(row, col));
						break;
					// string (for text)
					case '"':
					case '\'':
						checkBuild(nodes, building, row, col);
						char quoteType = cur;
						string text = "";
						for(int x = i + 1; x < input.Length; x++)
						{
							if (input[x] == quoteType)
							{
								if(text[text.Length - 1] == '\\')
								{
									text = text.Substring(0, text.Length - 1);
									text += quoteType;
								}
								else
								{
									nodes.Add(new TextNode(quoteType, text, row, col));
									i += x + 1;
									col += x + 1;
									break;
								}
							}
							else
								text += input[x];
						}
						break;

                    case ' ':
						checkBuild(nodes, building, row, col);
                        break;

                    default:
                        building += cur;
                        break;
                }

                col++;
            }

            return nodes.ToArray();
        }

		private static void checkBuild(List<BuildingNode> nodes, string building, int row, int col)
		{
			if (building == "")
				return;

			int actcol = col - building.Length;
			if (float.TryParse(building, out float maybe))
			{
				nodes.Add(new NumNode(maybe, row, actcol));
			}
			else
			{
				checkKeyword(nodes, building, row, actcol);
				if(building != "")
					nodes.Add(new IdentifierNode(building, row, actcol));
			}
			building = "";
		}

		private static void checkKeyword(List<BuildingNode> nodes, string building, int row, int col)
		{
			switch(building)
			{
				// statements
				case "if":
					nodes.Add(new IfNode(row, col));
					break;
				case "else":
					nodes.Add(new ElseNode(row, col));
					break;
				case "switch":
					nodes.Add(new SwitchNode(row, col));
					break;
				// loops
				case "do":
					nodes.Add(new DoNode(row, col));
					break;
				case "for":
					nodes.Add(new ForNode(row, col));
					break;
				case "while":
					nodes.Add(new WhileNode(row, col));
					break;
				// data structures
				case "letter":
					nodes.Add(new LetterKeywordNode(row, col));
					break;
				case "logic":
					nodes.Add(new LogicKeywordNode(row, col));
					break;
				case "num":
					nodes.Add(new NumKeywordNode(row, col));
					break;
				case "text":
					nodes.Add(new TextKeywordNode(row, col));
					break;
				// literals
				case "true":
					nodes.Add(new LogicNode(true, row, col));
					break;
				case "false":
					nodes.Add(new LogicNode(false, row, col));
					break;
				default:
					return;
			}
			building = "";
		}
    }
}
