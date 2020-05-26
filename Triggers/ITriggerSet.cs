using System.Collections.Generic;

namespace IngameScript.Triggers
{
	interface ITriggerSet
	{
		IEnumerable<BaseTrigger> Triggers { get; }
	}
}
