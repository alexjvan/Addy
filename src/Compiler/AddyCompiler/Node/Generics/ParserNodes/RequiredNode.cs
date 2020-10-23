using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node.Generics
{
	public class RequiredNode<T> : RequiredNode where T : BuildingNode
	{
		public new T Contents
		{
			get
			{
				return (T)_contents;
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

		public RequiredNode(T contents)
		{
			_contents = contents;
		}

		public override bool insertNode(BuildingNode n)
		{
			if (n.GetType() is T)
			{
				_contents = n;
				return true;
			}
			return false;
		}

	}
}
