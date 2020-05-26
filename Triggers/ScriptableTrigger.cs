using System;

namespace IngameScript.Triggers
{
	class ScriptableTrigger : BaseTrigger
	{
		private readonly Func<bool> _action;

		public ScriptableTrigger(Func<bool> action)
		{
			_action = action;
		}

		public override void Update()
		{
			if (_action())
			{
				Trigger();
			}
		}
	}
}
