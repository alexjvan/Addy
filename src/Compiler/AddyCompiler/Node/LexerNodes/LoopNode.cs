﻿using AddyCompiler.Node.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public abstract class LoopNode : StatementNode
	{
		public LoopNode(NodeType type, string value, int row, int col) : base(type, value, row, col) { }
	}
}
