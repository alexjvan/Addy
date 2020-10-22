using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public abstract class ReqNode
	{
		public abstract bool insertNode(BuildingNode n);

		public bool hasRequired()
		{
			return false;
		}

	}
}
