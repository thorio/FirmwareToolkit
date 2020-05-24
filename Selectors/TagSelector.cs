using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using System.Linq;
using IngameScript.Extensions;

namespace IngameScript
{
	partial class Program
	{
		class TagSelector<T> : BaseSelector<T> where T : IMyTerminalBlock
		{
			public TagSelector(string tag) : base(tag) { }

			public override IEnumerable<T> GetBlocks_Inner() =>
				Instance.GridTerminalSystem.GetBlocksWithTag(_identifier).OfType<T>();
		}
	}
}
