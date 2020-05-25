using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using System.Linq;

namespace IngameScript.Selectors
{
	class NameSelector<T> : TagSelector<T> where T : IMyTerminalBlock
	{
		public NameSelector(string name) : base(name) { }

		public override IEnumerable<T> GetBlocks_Inner() =>
			base.GetBlocks_Inner().Where((b) => b.Name == _identifier);
	}
}
