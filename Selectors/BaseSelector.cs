using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace IngameScript.Selectors
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

		public IEnumerable<T> GetBlocks()
		{
			_blocks = _blocks ?? GetBlocks_Inner();
			return _blocks;
		}

		public IEnumerable<IMyTerminalBlock> GetTerminalBlocks() =>
			GetBlocks().Cast<IMyTerminalBlock>();

		public T GetBlock() =>
			GetBlocks().First();

		public ISelector<TCast> As<TCast>() where TCast : IMyTerminalBlock =>
			new CastSelector<T, TCast>(this);
	}
}
