using AddyCompiler.Node;
using AddyCompiler.Parser.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Parser
{
    public class Pal
    {
        public static RootNode Parse(LexerNode[] nodes, out ParseError[] errors)
        {
            List<ParseError> foundErrors = new List<ParseError>();

            RootNode rn = new RootNode();

            int nodeIndex = 0;

            bool done = false;

            // possible entry points
            //      Not Required - ImportNode
            //      (class, guide, switch)*
            //      (function)*
            //      (statements)*

            // EMPTY FILE
            if (nodes.Length == 0)
            {
                TopLevelNode tln = new TopLevelNode(0, 0);
                rn.insertNode(tln);
                errors = foundErrors.ToArray();
                return rn;
            }

            bool doneImports = false;
            while (!done)
            {
                LexerNode curNode = nodes[nodeIndex];
                if (!doneImports && curNode.Type == NodeType.ImportKeywordNode)
                {
                    // Possibilities
                    //      import textnode semicolon ("test.addy";)
                    //      import textnode askeyword identifier semicolon (import "test1.addy" as t1;)
                    //      (Can end with next line being another import - CHECK
                    ImportBlockNode curMasterIBlock = null;
                    while (curNode.Type == NodeType.ImportKeywordNode)
                    {
                        ImportBlockNode newIblock = new ImportBlockNode(curNode.Row, curNode.Col);
                        ImportNode import = new ImportNode(curNode.Row, curNode.Col);
                        // Build Import Node
                        if (!import.insertNode((TextNode)nodes[++nodeIndex]))
                            foundErrors.Add(new NotExpectedNodeError(NodeType.TextNode, nodes[nodeIndex]));

                        if (nodes[nodeIndex++].Type == NodeType.AsKeywordNode)
                        {
                            try
                            {
                                if (!import.insertNode((AsKeywordNode)nodes[nodeIndex]))
                                    foundErrors.Add(new CouldntInsertNodeError(nodes[nodeIndex], import));
                            }
                            catch (InvalidCastException)
                            {
                                foundErrors.Add(new NotExpectedNodeError(NodeType.AsKeywordNode, nodes[nodeIndex]));
                            }

                            try
                            {
                                if (!import.insertNode((IdentifierNode)nodes[++nodeIndex]))
                                    foundErrors.Add(new CouldntInsertNodeError(nodes[nodeIndex], import));
                            }
                            catch (InvalidCastException)
                            {
                                foundErrors.Add(new NotExpectedNodeError(NodeType.IdentifierNode, nodes[nodeIndex]));
                            }

                            try
                            {
                                if (!import.insertNode((SemiColonNode)nodes[++nodeIndex]))
                                    foundErrors.Add(new CouldntInsertNodeError(nodes[nodeIndex], import));
                            }
                            catch (InvalidCastException)
                            {
                                foundErrors.Add(new NotExpectedNodeError(NodeType.SemiColonToken, nodes[nodeIndex]));
                            }
                        }
                        else
                        {
                            if (!import.insertNode((SemiColonNode)nodes[nodeIndex]))
                                foundErrors.Add(new NotExpectedNodeError(NodeType.SemiColonToken, nodes[nodeIndex]));
                        }
                        // Chain Import Block
                        if (curMasterIBlock == null)
                            curMasterIBlock = newIblock;
                        else
                        {
                            if (!newIblock.insertNode(curMasterIBlock))
                                foundErrors.Add(new CouldntInsertNodeError(curMasterIBlock, newIblock));
                            curMasterIBlock = newIblock;
                        }
                    }
                    doneImports = true;
                }
                else
                {
                    // SHOULD be pointing to whatever is after the last '}' or ';' - end of file
                    TopLevelNode topLvl = parseTopLevel(nodes, nodeIndex, foundErrors);

                    rn.insertNode(topLvl);

                    done = true;
                }
            }

            errors = foundErrors.ToArray();
            return rn;
        }

        private static TopLevelNode parseTopLevel(LexerNode[] nodes, int nodeIndex, List<ParseError> errors)
        {
            // Cur node will either be pointing to
            // The starting node in the file
            // The node right after the imports
            LexerNode curNode = nodes[nodeIndex];
            TopLevelNode curTop = new TopLevelNode(curNode.Row, curNode.Col);

            // Either start of file and not null
            // Or just finished with imports & can be null
            bool done = false;
            while (!done)
            {
                curNode = nodes[nodeIndex];
                if (nodeIndex >= nodes.Length)
                {
                    done = true;
                    continue;
                }
                if (curNode.Type == NodeType.ClassKeywordNode ||
                    curNode.Type == NodeType.GuideKeywordNode ||
                    curNode.Type == NodeType.SwitchKeywordNode)
                {
                    // After this - should be pointing to the thing after the '}'
                    // No change needed before returning
                    DataStructureDeclarationListNode newNode = parseDataStructureDeclarationList(nodes, nodeIndex, errors);
                    curTop.insertNode(newNode);
                }
                else if (curNode.Type == NodeType.FunctionKeywordNode ||
                         curNode.Type == NodeType.EntryKeywordNode)
                {
                    // TODO
                    // After this - should be pointing to the thing after the '}'
                    // No change needed before returning
                }
                else if (curNode.Type == NodeType.PublicKeywordNode ||
                         curNode.Type == NodeType.FriendlyKeywordNode ||
                         curNode.Type == NodeType.PrivateKeywordNode ||
                         curNode.Type == NodeType.LocalKeywordNode ||
                         curNode.Type == NodeType.GlobalKeywordNode)
                {
                    // Scope and privacy variables will be handled in method and class declarations
                    // No need to interact with them - let them be
                    continue;
                }
                else
                {
                    // TODO - Generic Statements
                }

            }

            return curTop;
        }

        private static ScopeDeclarationNode parseScopeDeclaration(LexerNode[] nodes, int nodeIndex, List<ParseError> errors)
        {
            // Cur node will either be pointing to a 'local', 'global'
            LexerNode curNode = nodes[nodeIndex];
            ScopeDeclarationNode scope = new ScopeDeclarationNode(curNode.Row, curNode.Col);

            // TODO

            return scope;
        }

        private static PrivacyDeclarationNode parsePrivacyDeclaration(LexerNode[] nodes, int nodeIndex, List<ParseError> errors)
        {
            // Cur node will either be pointing to a 'private', 'friendly', 'public'
            LexerNode curNode = nodes[nodeIndex];
            PrivacyDeclarationNode privacy = new PrivacyDeclarationNode(curNode.Row, curNode.Col);

            if (curNode.Type == NodeType.PrivateKeywordNode)
                privacy.insertNode((PrivateKeywordNode)curNode);
            else if (curNode.Type == NodeType.FriendlyKeywordNode)
                privacy.insertNode((FriendlyKeywordNode)curNode);
            else if (curNode.Type == NodeType.PublicKeywordNode)
                privacy.insertNode((PublicKeywordNode)curNode);

            return privacy;
        }

        private static DataStructureDeclarationListNode parseDataStructureDeclarationList(LexerNode[] nodes, int nodeIndex, List<ParseError> errors)
        {
            // Cur node will either be pointing to a 'class', 'guide', 'switch'
            LexerNode curNode = nodes[nodeIndex];
            DataStructureDeclarationListNode curTop = new DataStructureDeclarationListNode(curNode.Row, curNode.Col);

            bool done = false;
            while(!done)
            {
                curNode = nodes[nodeIndex];
                if (nodeIndex >= nodes.Length)
				{
                    done = true;
                    continue;
				}
                if(curNode.Type == NodeType.ClassDeclarationNode)
				{
                    // After this - should be pointing to the thing after the '}'
                    // No change needed before returning
                    ClassDeclarationNode newNode = parseClassDeclaration(nodes, nodeIndex, errors);
                    curTop.insertNode(newNode);
				}
                else if (curNode.Type == NodeType.GuideDeclarationNode)
				{
                    // TODO
				}
                else if(curNode.Type == NodeType.SwitchKeywordNode)
				{
                    // TODO
				}
                else
				{
                    // TODO
				}
			}

            return curTop;
        }

        private static ClassDeclarationNode parseClassDeclaration(LexerNode[] nodes, int nodeIndex, List<ParseError> errors)
		{
            // Cur node will be pointing to a 'class'
            LexerNode curNode = nodes[nodeIndex];
            ClassDeclarationNode cur = new ClassDeclarationNode(curNode.Row, curNode.Col);

            // Deal with privacy - if it exists
            if(nodeIndex != 0 &&
               (nodes[nodeIndex - 1].Type == NodeType.PrivateKeywordNode ||
                nodes[nodeIndex - 1].Type == NodeType.FriendlyKeywordNode ||
                nodes[nodeIndex - 1].Type == NodeType.PublicKeywordNode))
			{
                PrivacyDeclarationNode privacy = parsePrivacyDeclaration(nodes, nodeIndex - 1, errors);
                cur.insertNode(privacy);
			}
            // 'class'
            cur.insertNode((ClassKeywordNode)curNode);

            // identifier - classname
            try
            {
                if (!cur.insertNode((IdentifierNode)nodes[++nodeIndex]))
                    errors.Add(new CouldntInsertNodeError(nodes[nodeIndex], cur));
            }
            catch (InvalidCastException)
            {
                errors.Add(new NotExpectedNodeError(NodeType.IdentifierNode, nodes[nodeIndex]));
            }

            ClassInternalsNode internals = parseClassInternals(nodes, ++nodeIndex, errors);
            cur.insertNode(internals);

            return cur;
        }

        private static ClassInternalsNode parseClassInternals(LexerNode[] nodes, int nodeIndex, List<ParseError> errors)
		{
            // Cur SHOULD be pointing to a '{' - after finishing parsing parsing the classname
            LexerNode curNode = nodes[nodeIndex];
            ClassInternalsNode cur = new ClassInternalsNode(curNode.Row, curNode.Col);
            // '{'
            try
            {
                if (!cur.insertNode((OpenBracketNode)nodes[nodeIndex]))
                    errors.Add(new CouldntInsertNodeError(nodes[nodeIndex], cur));
            }
            catch (InvalidCastException)
            {
                errors.Add(new NotExpectedNodeError(NodeType.OpenBracketToken, nodes[nodeIndex]));
            }

            // After this - should be pointing at the next '}'
            ClassRepeatableNode repeatable = parseClassRepeatable(nodes, ++nodeIndex, errors);

            // '}'
            try
            {
                if (!cur.insertNode((CloseBracketNode)nodes[nodeIndex]))
                    errors.Add(new CouldntInsertNodeError(nodes[nodeIndex], cur));
            }
            catch (InvalidCastException)
            {
                errors.Add(new NotExpectedNodeError(NodeType.CloseBracketToken, nodes[nodeIndex]));
            }

            return cur;
        }

        private static ClassRepeatableNode parseClassRepeatable(LexerNode[] nodes, int nodeIndex, List<ParseError> errors)
        {
            // Cur should be pointing to whatever is right after the '{'
            LexerNode curNode = nodes[nodeIndex];
            ClassRepeatableNode cur = new ClassRepeatableNode(curNode.Row, curNode.Col);

            bool done = false;
            while(!done)
            {
                curNode = nodes[nodeIndex];
                if (curNode.Type == NodeType.CloseBracketToken ||
                    nodeIndex >= nodes.Length)
				{
                    done = true;
                    continue;
				}
			}

            return cur;
        }

        private static FunctionDeclarationListNode parseFunctionDeclarationList(LexerNode[] nodes, int nodeIndex, List<ParseError> errors)
        {
            // Cur node will either be pointing to a 'function', 'entry'
            LexerNode curNode = nodes[nodeIndex];
            FunctionDeclarationListNode curTop = new FunctionDeclarationListNode(curNode.Row, curNode.Col);

            // TODO

            return curTop;
        }

        private static EntryPointDeclarationNode parseEntryPointDeclaration(LexerNode[] nodes, int nodeIndex, List<ParseError> errors)
        {
            // Cur node will either be pointing to a 'entry'
            LexerNode curNode = nodes[nodeIndex];
            EntryPointDeclarationNode cur = new EntryPointDeclarationNode(curNode.Row, curNode.Col);

            // TODO

            return cur;
        }

        private static FunctionDeclarationNode parseFunctionDeclaration(LexerNode[] nodes, int nodeIndex, List<ParseError> errors)
        {
            // Cur node will either be pointing to a 'function'
            LexerNode curNode = nodes[nodeIndex];
            FunctionDeclarationNode cur = new FunctionDeclarationNode(curNode.Row, curNode.Col);

            // TODO

            return cur;
        }

    }
}
