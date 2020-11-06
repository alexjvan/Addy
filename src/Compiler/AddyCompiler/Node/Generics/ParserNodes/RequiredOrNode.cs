﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddyCompiler.Node.Generics
{
	public class RequiredOrNode<T, U> : RequiredAndNode where T : ReqNode where U : ReqNode
	{
		public new T One
		{
			get
			{
				return (T)_one;
			}
			set
			{
				if (value == null)
					_one = new RequiredNode();
				else
					_one = value;
			}
		}

		public new U Two
		{
			get
			{
				return (U)_two;
			}
			set
			{
				if (value == null)
					_two = new RequiredNode();
				else
					_two = value;
			}
		}

		public RequiredOrNode()
		{
			_one = null;
			_two = null;
		}

		public RequiredOrNode(T one)
		{
			_one = one;
			_two = null;
		}

		public RequiredOrNode(U two)
		{
			_one = null;
			_two = two;
		}

		public RequiredOrNode(T one, U two)
		{
			_one = one;
			_two = two;
		}

		public override bool insertNode(LexerNode n)
		{
			// TODO -- redo
			bool suc = false;
			suc = _one.insertNode(n);
			if (suc)
				return true;

			suc = _one.insertNode(n);
			if (suc)
				return true;
			return false;
		}

	}
}
