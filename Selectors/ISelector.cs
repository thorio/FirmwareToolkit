using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;

namespace IngameScript.Selectors
{
	interface ISelector<T>
	{
		/// <summary>
		/// Produces a selector of a different type
		/// </summary>
		ISelector<TCast> As<TCast>() where TCast : IMyTerminalBlock;
		/// <summary>
		/// Returns the selected blocks
		/// </summary>
		IEnumerable<T> GetBlocks();
		/// <summary>
		/// Returns the first selected block
		/// </summary>
		T GetBlock();
	}
}
