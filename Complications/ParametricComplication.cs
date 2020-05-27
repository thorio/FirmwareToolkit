using IngameScript.Actions;
using IngameScript.Triggers;

namespace IngameScript.Complications
{
	abstract class ParametricComplication<T> : ActionContainer, IParametricAction<T>
	{
		public abstract void Execute(T parameter);

		public virtual ParametricComplication<T> Then(IAction action)
		{
			AddAction(action);
			return this;
		}
	}
}
