using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;

namespace IngameScript
{
	partial class Program
	{
		interface ISelector<T>
		{
			ISelector<TCast> As<TCast>() where TCast : IMyTerminalBlock;
			IEnumerable<T> GetBlocks();
		}
	}
}
