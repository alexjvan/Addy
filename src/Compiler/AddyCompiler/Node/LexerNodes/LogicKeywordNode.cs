﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class LogicKeywordNode : KeywordNode
	{
		public LogicKeywordNode(int row, int col) : base(NodeType.LogicKeywordNode, "logic", row, col) { }
	}
}
