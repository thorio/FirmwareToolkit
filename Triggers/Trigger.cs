using IngameScript.Actions;
using System.Collections.Generic;

namespace IngameScript.Triggers
{
	abstract class Trigger : ActionContainer
	{
		public virtual void RegisterIn(TriggerSet triggerSet)
		{
			triggerSet.Register(this);
		}

		/// <summary>
		/// Called on script update. Checks conditions and triggers actions if appropriate
		/// </summary>
		public virtual void Update() { }

		public virtual Trigger Then(IAction action)
		{
			AddAction(action);
			return this;
		}
	}
}
