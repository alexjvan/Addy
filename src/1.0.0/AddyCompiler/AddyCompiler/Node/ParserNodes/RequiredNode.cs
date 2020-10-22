using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public class RequiredNode : ReqNode
	{

		internal BuildingNode _contents;

		public BuildingNode Contents
		{
			get
			{
				return _contents;
			}
			set
			{
				_contents = value;
			}
		}

		public RequiredNode()
		{
			_contents = null;
		}

		public RequiredNode(BuildingNode contents)
		{
			_contents = contents;
		}

		public new bool hasRequired()
		{
			if (Contents != null)
				return true;
			return false;
		}

		public override bool insertNode(BuildingNode n)
		{
			_contents = n;
			return true;
		}
	}
}
