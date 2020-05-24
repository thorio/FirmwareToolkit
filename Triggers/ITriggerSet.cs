using System.Collections.Generic;

namespace IngameScript
{
	interface ITriggerSet
	{
		IEnumerable<BaseTrigger> Triggers { get; }
	}
}
