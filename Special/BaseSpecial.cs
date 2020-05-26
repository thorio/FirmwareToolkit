using IngameScript.Actions;
using IngameScript.Triggers;

namespace IngameScript.Special
{
	// TODO naming
	abstract class BaseSpecial : ActionContainer, IAction
	{
		public abstract void Execute();

		public virtual BaseSpecial Then(IAction action)
		{
			AddAction(action);
			return this;
		}
	}
}
