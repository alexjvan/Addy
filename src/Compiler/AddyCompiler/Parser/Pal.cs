﻿using AddyCompiler.Node;
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

            // TODO: Add this in too
            // If can't cast to right thing its an invalid cast exception

            bool doneImports = false;
            while(!done)
            {
                LexerNode curNode = nodes[nodeIndex];
                if(!doneImports && curNode.Type == NodeType.ImportKeywordNode)
				{
                    // Possibilities
                    //      import textnode semicolon ("test.addy";)
                    //      import textnode askeyword identifier semicolon (import "test1.addy" as t1;)
                    //      (Can end with next line being another import - CHECK
                    ImportBlockNode curMasterIBlock = null;
                    while(curNode.Type == NodeType.ImportKeywordNode)
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
                            catch(InvalidCastException)
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
                                foundErrors.Add(new NotExpectedNodeError(NodeType.AsKeywordNode, nodes[nodeIndex]));
                            }

                            try
                            {
                                if (!import.insertNode((SemiColonNode)nodes[++nodeIndex]))
                                    foundErrors.Add(new CouldntInsertNodeError(nodes[nodeIndex], import));
                            }
                            catch (InvalidCastException)
                            {
                                foundErrors.Add(new NotExpectedNodeError(NodeType.AsKeywordNode, nodes[nodeIndex]));
                            }
                        }
                        else
                        {
                            if (!import.insertNode((SemiColonNode)nodes[nodeIndex]))
                                foundErrors.Add(new NotExpectedNodeError(NodeType.SemiColonToken, nodes[nodeIndex]));
                        }
                        // Chain Import Block
                        if(curMasterIBlock == null)
                            curMasterIBlock = newIblock;
                        else
						{
                            if(!newIblock.insertNode(curMasterIBlock))
                                foundErrors.Add(new CouldntInsertNodeError(curMasterIBlock, newIblock));
                            curMasterIBlock = newIblock;
						}
                    }
                    doneImports = true;
                }
                else
				{
                    TopLevelNode topLvl = parseTopLevel(nodes, nodeIndex, foundErrors);

                    

                    done = true;
				}
            }

            errors = foundErrors.ToArray();
            return rn;
        }

        private static TopLevelNode parseTopLevel(LexerNode[] nodes, int nodeIndex, List<ParseError> errors)
        {
            LexerNode curNode = nodes[nodeIndex];
            TopLevelNode topLvl = new TopLevelNode(curNode.Row, curNode.Col);

            return topLvl;
        }
    }
}
