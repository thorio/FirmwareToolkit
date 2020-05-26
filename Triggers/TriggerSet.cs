using System.Collections.Generic;

namespace IngameScript.Triggers
{
	class TriggerSet : ITriggerSet
	{
		public TriggerSet()
		{
			_triggers = new List<Trigger>();
		}

		private readonly List<Trigger> _triggers;

		public IEnumerable<Trigger> Triggers => _triggers;

		public TriggerSet Register(Trigger trigger)
		{
			_triggers.Add(trigger);
			return this;
		}

		public TriggerSet Register(IEnumerable<Trigger> triggers)
		{
			_triggers.AddRange(triggers);
			return this;
		}

		public TriggerSet Register(ITriggerSet triggerSet)
		{
			return Register(triggerSet.Triggers);
		}
	}
}
