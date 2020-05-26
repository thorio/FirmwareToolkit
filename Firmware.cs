using IngameScript.Timing;
using IngameScript.Triggers;
using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IngameScript
{
	class Firmware
	{
		public static Firmware Instance { get; private set; }
		public static IMyGridTerminalSystem Grid => Instance.Program.GridTerminalSystem;

		private List<ArgumentTrigger> _argumentTriggers;
		private List<Trigger> _triggers;

		public Firmware(Program program, Action<TriggerSet> configureAction)
		{
			if (Instance != null) {
				throw new InvalidOperationException();
			}
			Instance = this;
			Program = program;

			var triggerSet = new TriggerSet();
			configureAction(triggerSet);
			_argumentTriggers = triggerSet.Triggers.OfType<ArgumentTrigger>().ToList();
			_triggers = triggerSet.Triggers.Where(x => !(x is ArgumentTrigger)).ToList();
		}

		public Program Program { get; }

		public void Update(string argument, UpdateType updateType)
		{
			switch (updateType)
			{
				case UpdateType.Terminal:
				case UpdateType.Trigger:
					_argumentTriggers.ForEach(t => t.Update(argument));
					break;
				default:
					_triggers.ForEach(t => t.Update());
					break;
			}
		}
	}
}
