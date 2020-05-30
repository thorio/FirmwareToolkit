using IngameScript.Triggers;
using System.Collections.Generic;

namespace IngameScript.Constructs
{
	abstract class Construct : ITriggerSet
	{
		protected List<Trigger> _triggers;

		public Construct()
		{
			_triggers = new List<Trigger>();
		}

		public IEnumerable<Trigger> Triggers => _triggers;

		public void RegisterIn(TriggerSet triggerSet)
		{
			triggerSet.Register(this);
		}
	}
}
