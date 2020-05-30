using IngameScript.Triggers;
using Sandbox.ModAPI.Ingame;
using SpaceEngineers.Game.ModAPI.Ingame;
using IngameScript.Constructs;
using IngameScript.Actions;
using IngameScript.Complications;

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
		//    bla. bla bla.
		const UpdateFrequency Frequency = UpdateFrequency.Update10;
		//
		//
		//    bla bla.
		//
		void Configure(TriggerSet triggers)
		{
			new AirlockConstruct(Tag<IMyDoor>("[SP-ADI]"), Tag<IMyDoor>("[SP-ADE]"), Tag<IMyAirVent>("[SP-AV]"))
				.AddArgumentTriggers("SPAirlock")
				.RegisterIn(triggers);
		}
		//
		//
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////////	
		#endregion

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
	}
}
