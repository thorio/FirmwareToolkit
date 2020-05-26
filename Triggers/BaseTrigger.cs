using IngameScript.Actions;
using System.Collections.Generic;

namespace IngameScript.Triggers
{
	abstract class BaseTrigger
	{
		protected BaseTrigger()
		{
			Actions = new List<IAction>();
		}

		protected List<IAction> Actions { get; set; }

		public virtual BaseTrigger AddAction(IAction action)
		{
			Actions.Add(action);
			return this;
		}

		public virtual void RegisterIn(TriggerSet triggerSet)
		{
			triggerSet.Register(this);
		}

		/// <summary>
		/// Triggers all associated actions
		/// </summary>
		protected virtual void Trigger()
		{
			Actions.ForEach(a => a.Execute());
		}

		/// <summary>
		/// Called on script update. Checks conditions and triggers actions if appropriate
		/// </summary>
		public virtual void Update()
		{
			// does nothing
		}
	}
}
