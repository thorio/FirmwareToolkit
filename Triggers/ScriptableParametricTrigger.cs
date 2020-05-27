using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRage;

namespace IngameScript.Triggers
{
	class ScriptableParametricTrigger<T> : ParametricTrigger<T>
	{
		private readonly Func<ValueTuple<bool, T>> _action;

		public ScriptableParametricTrigger(Func<ValueTuple<bool, T>> action)
		{
			_action = action;
		}

		public override void Update()
		{
			var result = _action();
			if (result.Item1)
			{
				Run(result.Item2);
				Run();
			}
		}
	}
}
