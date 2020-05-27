using IngameScript.Actions;
using System.Collections.Generic;

namespace IngameScript.Triggers
{
	class ParametricTrigger<T> : Trigger
	{
		protected List<IParametricAction<T>> _parametricActions;

		protected ParametricTrigger()
		{
			_parametricActions = new List<IParametricAction<T>>();
		}

		/// <summary>
		/// Triggers all associated actions
		/// </summary>
		protected void Run(T parameter)
		{
			_parametricActions.ForEach(a => a.Execute(parameter));
			Run();
		}

		public ParametricTrigger<T> Then(IParametricAction<T> action)
		{
			_parametricActions.Add(action);
			return this;
		}
	}
}
