﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class PrivateKeywordNode : KeywordNode
	{

		public PrivateKeywordNode(int row, int col) : base(NodeType.PrivateKeywordNode, "private", row, col) { }

	}
}
