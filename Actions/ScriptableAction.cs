using System;

namespace IngameScript
{
	partial class Program
	{
		class ScriptableAction : IAction
		{
			private readonly Action _action;

			public ScriptableAction(Action action)
			{
				_action = action;
			}

			public void Execute()
			{
				_action();
			}
		}
	}
}
