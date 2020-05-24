﻿using System.Collections.Generic;

namespace IngameScript.Triggers
{
	class TriggerSet : ITriggerSet
	{
		public TriggerSet()
		{
			_triggers = new List<BaseTrigger>();
		}

		private readonly List<BaseTrigger> _triggers;

		public IEnumerable<BaseTrigger> Triggers => _triggers;

		public TriggerSet Register(BaseTrigger trigger)
		{
			_triggers.Add(trigger);
			return this;
		}

		public TriggerSet Register(IEnumerable<BaseTrigger> triggers)
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
