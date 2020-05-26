using IngameScript.Actions;
using System.Collections.Generic;

namespace IngameScript.Triggers
{
	class ActionContainer
	{
		protected ActionContainer()
		{
			Actions = new List<IAction>();
		}

		protected List<IAction> Actions { get; }

		public void AddAction(IAction action)
		{
			Actions.Add(action);
		}

		/// <summary>
		/// Triggers all associated actions
		/// </summary>
		protected virtual void Run()
		{
			Actions.ForEach(a => a.Execute());
		}
	}
}
