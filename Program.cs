using IngameScript.Actions;
using IngameScript.Selectors;
using IngameScript.Special;
using IngameScript.Triggers;
using Sandbox.ModAPI.Ingame;
using SpaceEngineers.Game.ModAPI.Ingame;
using System.Collections.Generic;
using System.Linq;

namespace IngameScript
{
	partial class Program : MyGridProgram
	{
		#region mdk preserve
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////   R E A D M E   /////////////////////////////////////////////
		//
		//
		//    bla.
		//
		//
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////   C O N F I G U R A T I O N   ////////////////////////////////////////
		//
		//
		//    bla bla.
		//
		//
		void Configure(TriggerSet triggers)
		{
			var myCondition = true;
			
			new ArgumentTrigger("Light")
				.Then(new Condition(() => myCondition)
					.Then(new OnOffAction(Tag<IMyFunctionalBlock>("[MyLight]"), Enabled.Toggle))
					)
				.RegisterIn(triggers);
		}
		//
		//
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////   S E T T I N G S   /////////////////////////////////////////////
		//
		//
		//    bla. bla bla.
		const UpdateFrequency Frequency = UpdateFrequency.Update10;
		//
		//
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////////	
		#endregion

		#region Program
		public static Program Instance { get; private set; }

		private readonly List<ArgumentTrigger> _argumentTriggers;
		private readonly List<Trigger> _triggers;

		public Program()
		{
			Instance = this;
			Runtime.UpdateFrequency = Frequency;

			var triggerSet = new TriggerSet();
			Configure(triggerSet);
			_argumentTriggers = triggerSet.Triggers.OfType<ArgumentTrigger>().ToList();
			_triggers = triggerSet.Triggers.Where(x => !(x is ArgumentTrigger)).ToList();
		}

		public void Main(string argument, UpdateType updateType)
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
		#endregion

		#region Selectors
		TagSelector<IMyTerminalBlock> Tag(string tag) => Tag<IMyTerminalBlock>(tag);
		TagSelector<T> Tag<T>(string tag) where T : IMyTerminalBlock => new TagSelector<T>(tag);
		GroupSelector<IMyTerminalBlock> Group(string name) => Group<IMyTerminalBlock>(name);
		GroupSelector<T> Group<T>(string name) where T : IMyTerminalBlock => new GroupSelector<T>(name);
		NameSelector<IMyTerminalBlock> Name(string name) => Name<IMyTerminalBlock>(name);
		NameSelector<T> Name<T>(string name) where T : IMyTerminalBlock => new NameSelector<T>(name);
		#endregion
	}
}
