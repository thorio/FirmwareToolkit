using IngameScript.Actions;
using IngameScript.Triggers;

namespace IngameScript.Complications
{
	abstract class Complication : ActionContainer, IAction
	{
		public abstract void Execute();

		public virtual Complication Then(IAction action)
		{
			AddAction(action);
			return this;
		}
	}
}
