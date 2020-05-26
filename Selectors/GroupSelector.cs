using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using System.Linq;
using IngameScript.Extensions;

namespace IngameScript.Selectors
{
	class GroupSelector<T> : BaseSelector<T> where T : IMyTerminalBlock
	{
		public GroupSelector(string name) : base(name) { }

		public override IEnumerable<T> GetBlocks_Inner() =>
			Firmware.Grid.GetBlockGroupWithName(_identifier).GetBlocks().OfType<T>();
	}
}
