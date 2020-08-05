﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class IfNode : StatementNode
	{
		public IfNode(int row, int col) : base(NodeType.IfKeywordNode, "if", row, col) { }
	}
}