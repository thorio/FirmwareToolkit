using IngameScript.Actions;
using System.Collections.Generic;

namespace IngameScript.Triggers
{
	class ActionContainer
	{
		protected List<IAction> _actions;

		protected ActionContainer()
		{
			_actions = new List<IAction>();
		}

		protected void AddAction(IAction action)
		{
			_actions.Add(action);
		}

		/// <summary>
		/// Triggers all associated actions
		/// </summary>
		protected virtual void Run()
		{
			_actions.ForEach(a => a.Execute());
		}
	}
}
