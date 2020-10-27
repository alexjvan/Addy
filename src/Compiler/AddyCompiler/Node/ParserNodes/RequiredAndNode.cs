using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node
{
	public abstract class RequiredAndNode : ReqNode
	{
		internal ReqNode _one;
		internal ReqNode _two;

		public ReqNode One
		{
			get
			{
				return _one;
			}
			set
			{
				if (value == null)
					_one = new RequiredNode();
				else
					_one = value;
			}
		}

		public ReqNode Two
		{
			get
			{
				return _two;
			}
			set
			{
				if (value == null)
					_two = new RequiredNode();
				else
					_two = value;
			}
		}

		public RequiredAndNode()
		{
			_one = new RequiredNode();
			_two = new RequiredNode();
		}

		public RequiredAndNode(LexerNode one, LexerNode two = null)
		{
			_one = new RequiredNode(one);
			_two = new RequiredNode(two);
		}

		public RequiredAndNode(ReqNode one, ReqNode two = null)
		{
			_one = one;
			_two = two;
		}

		public new bool hasRequired()
		{
			if (_one.hasRequired() && _two.hasRequired())
				return true;
			return false;
		}

	}
}
