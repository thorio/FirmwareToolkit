﻿using IngameScript.Actions;
using System;

namespace IngameScript.Special
{
	class Condition : BaseSpecial
	{
		private Func<bool> _condition;

		public Condition(Func<bool> condition)
		{
			_condition = condition;
		}

		public override void Execute()
		{
			if (_condition()) {
				Run();
			}
		}
	}
}
