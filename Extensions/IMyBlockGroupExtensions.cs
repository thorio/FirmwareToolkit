using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;

namespace IngameScript.Extensions
{
	public static class IMyBlockGroupExtensions
	{
		public static List<IMyTerminalBlock> GetBlocks(this IMyBlockGroup group)
		{
			var blocks = new List<IMyTerminalBlock>();
			group.GetBlocks(blocks);
			return blocks;
		}
	}
}
