using System.Collections.Generic;

namespace IngameScript
{
	partial class Program
	{
		interface ITriggerSet
		{
			IEnumerable<BaseTrigger> Triggers { get; }
		}
	}
}
