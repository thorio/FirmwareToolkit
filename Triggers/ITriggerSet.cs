using System.Collections.Generic;

namespace IngameScript.Triggers
{
	interface ITriggerSet
	{
		IEnumerable<Trigger> Triggers { get; }
	}
}
