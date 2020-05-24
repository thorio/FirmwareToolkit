using IngameScript.Selectors;
using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;

namespace IngameScript.Actions
{
	/// <summary>
	/// Toggles all blocks with tag
	/// </summary>
	class OnOffAction : BlockAction<IMyFunctionalBlock>
	{
		private readonly Enabled _action;
		public OnOffAction(ISelector<IMyFunctionalBlock> selector, Enabled action) : base(selector)
		{
			_action = action;
		}

		protected override void Execute(IEnumerable<IMyFunctionalBlock> blocks)
		{
			foreach (var block in blocks)
			{
				switch (_action)
				{
					case Enabled.On:
						block.Enabled = true;
						break;
					case Enabled.Off:
						block.Enabled = false;
						break;
					case Enabled.Toggle:
						block.Enabled = !block.Enabled;
						break;
				}

			}
		}
	}
}
