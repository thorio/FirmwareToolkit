using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;

namespace IngameScript.Extensions
{
	public static class IMyGridTerminalSystemExtensions
	{
		public static List<IMyTerminalBlock> GetBlocksWithTag(this IMyGridTerminalSystem grid, string tag)
		{
			var blocks = new List<IMyTerminalBlock>();
			grid.SearchBlocksOfName(tag, blocks);
			return blocks;
		}
	}
}
