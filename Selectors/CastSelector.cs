using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace IngameScript
{
	partial class Program
	{
		class CastSelector<TSource, TTarget> : BaseSelector<TTarget> where TTarget : IMyTerminalBlock
		{
			private ISelector<TSource> _selector;

			public CastSelector(ISelector<TSource> selector)
			{
				_selector = selector;
			}

			public override IEnumerable<TTarget> GetBlocks_Inner()
			{
				var blocks = _selector.GetBlocks();
				_selector = null; // cleanup reference so GC can kick in
				return blocks.Cast<TTarget>();
			}
		}
	}
}
