using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class NullNode : ReqNode
	{
		public new bool hasRequired()
		{
			return true;
		}

		public override bool insertNode(LexerNode n)
		{
			return false;
		}
	}
}
