using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace IngameScript
{
	partial class Program
	{
		abstract class BaseSelector<T> : ISelector<T> where T : IMyTerminalBlock
		{
			protected readonly string _identifier;
			protected IEnumerable<T> _blocks;
			public BaseSelector(string identifier = null)
			{
				_identifier = identifier;
			}
			public abstract IEnumerable<T> GetBlocks_Inner();

			public IEnumerable<IMyTerminalBlock> GetTerminalBlocks() =>
				GetBlocks().Cast<IMyTerminalBlock>();

			public IEnumerable<T> GetBlocks()
			{
				_blocks = _blocks ?? GetBlocks_Inner();
				return _blocks;
			}

			public ISelector<TCast> As<TCast>() where TCast : IMyTerminalBlock
			{
				return new CastSelector<T, TCast>(this);
			}
		}
	}
}
