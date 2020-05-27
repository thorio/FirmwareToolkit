using System;

namespace IngameScript.Complications
{
	class ParametricCondition<T> : ParametricComplication<T>
	{
		private Func<T, bool> _condition;

		public ParametricCondition(Func<T, bool> condition)
		{
			_condition = condition;
		}

		public override void Execute(T parameter)
		{
			if (_condition(parameter))
			{
				Run();
			}
		}
	}
}
