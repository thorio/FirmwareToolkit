﻿using IngameScript.Actions;
using IngameScript.Selectors;
using IngameScript.Complications;
using IngameScript.Triggers;
using Sandbox.ModAPI.Ingame;
using SpaceEngineers.Game.ModAPI.Ingame;

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
			new ArgumentTrigger("Light")
				.Then(new Delay(500)
					.Then(new OnOffAction(Tag<IMyFunctionalBlock>("[MyLight]"), Enabled.Toggle))
					)
				.RegisterIn(triggers);

			var myCondition = false;

			new ArgumentTrigger("ToggleLight")
				.Then(new ScriptableAction(() => myCondition = !myCondition))
				.RegisterIn(triggers);

			new IntervalTrigger(1000)
				.Then(new Condition(() => myCondition)
					.Then(new OnOffAction(Tag<IMyFunctionalBlock>("[MyLight2]"), Enabled.Toggle))
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
		private Firmware _firmware;

		public Program()
		{
			Runtime.UpdateFrequency = Frequency;
			_firmware = new Firmware(this, Configure);
		}

		public void Main(string argument, UpdateType updateType)
		{
			_firmware.Update(argument, updateType);
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
