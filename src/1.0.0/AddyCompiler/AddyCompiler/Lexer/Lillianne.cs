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
						checkBuild(nodes, building, row, col);
						// only increase col by three because the next will increase it by one more
						col += 3;
                        break;
					case '#':
						checkBuild(nodes, building, row, col);
						// multiline comment
						if (input[i + 1] == '-')
						{
							bool done = false;
							i += 2;
							col += 2;
							cur = input[i];
							while(!done)
							{
								while (cur != '-')
								{
									i++;
									col++;
									cur = input[i];
									if(cur == '\n')
									{
										row++;
										col = 0;
									}
								}
								i++;
								col++;
								cur = input[i];
								if (cur == '#')
									done = true;
							}
						}
						// ONLY NODE THAT WILL BE ABLE TO BE PRE-BUILT GOING INTO PARSER (NO OTHER WAY OF GOING ABOUT IT BUDDY)
						// compiler declaration
						else if(input[i + 1] == '!')
						{
							string maxi = "";
							while(cur != '\n')
							{
								i++;
								cur = input[i];
								if (cur != '\n')
									maxi += cur;
							}
							i--;
							nodes.Add(new CompilerDeclarationNode(maxi, row, col));
						}
						// singleline comment
						else
						{
							while (cur != '\n')
							{
								i++;
								cur = input[i];
							}
							i--;
						}
						break;

					// operators
					case '=':
						checkBuild(nodes, building, row, col);
						nodes.Add(new EqualsNode(row, col));
						break;
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
					case '!':
						checkBuild(nodes, building, row, col);
						nodes.Add(new ExclamationNode(row, col));
						break;
					case '(':
						checkBuild(nodes, building, row, col);
						nodes.Add(new OpenParenthesisNode(row, col));
						break;
					case ')':
						checkBuild(nodes, building, row, col);
						nodes.Add(new CloseParenthesisNode(row, col));
						break;
					case '[':
						checkBuild(nodes, building, row, col);
						nodes.Add(new OpenBraceNode(row, col));
						break;
					case ']':
						checkBuild(nodes, building, row, col);
						nodes.Add(new CloseBraceNode(row, col));
						break;
					case '{':
						checkBuild(nodes, building, row, col);
						nodes.Add(new OpenBracketNode(row, col));
						break;
					case '}':
						checkBuild(nodes, building, row, col);
						nodes.Add(new CloseBracketNode(row, col));
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
				nodes.Add(new NumNode(maybe, row, actcol));
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
					nodes.Add(new IfKeywordNode(row, col));
					break;
				case "else":
					nodes.Add(new ElseNode(row, col));
					break;
				case "gate":
					nodes.Add(new GateKeywordNode(row, col));
					break;
				// loops
				case "do":
					nodes.Add(new DoNode(row, col));
					break;
				case "for":
					nodes.Add(new ForKeywordNode(row, col));
					break;
				case "while":
					nodes.Add(new WhileNode(row, col));
					break;
				// data structures
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
				// functions
				case "class":
					nodes.Add(new ClassKeywordNode(row, col));
					break;
				case "guide":
					nodes.Add(new GuideKeywordNode(row, col));
					break;
				case "switch":
					nodes.Add(new SwitchKeywordNode(row, col));
					break;
				case "fun":
					nodes.Add(new FunctionKeywordNode(row, col));
					break;
				case "entry":
					nodes.Add(new EntryKeywordNode(row, col));
					break;
				case "return":
					nodes.Add(new ReturnKeywordNode(row, col));
					break;
				// scope
				case "global":
					nodes.Add(new GlobalKeywordNode(row, col));
					break;
				case "local":
					nodes.Add(new LocalKeywordNode(row, col));
					break;
				// privacy
				case "public":
					nodes.Add(new PublicKeywordNode(row, col));
					break;
				case "friendly":
					nodes.Add(new FriendlyKeywordNode(row, col));
					break;
				case "private":
					nodes.Add(new PrivateKeywordNode(row, col));
					break;
				// importing
				case "import":
					nodes.Add(new ImportKeywordNode(row, col));
					break;
				case "as":
					nodes.Add(new AsKeywordNode(row, col));
					break;
				default:
					return;
			}
			building = "";
		}
    }
}
