using IngameScript.Selectors;
using Sandbox.ModAPI.Ingame;

namespace IngameScript.Triggers
{
	class DoorStatusChangedTrigger : ParametricTrigger<DoorStatus>
	{
		private IMyDoor _door;
		private DoorStatus _doorStatus;
		private bool _eager;
		private bool _raw;

		/// <param name="eager">Should the trigger execute as soon as the door starts opening?</param>
		/// <param name="raw">Use raw status. Triggers twice: Opening, Open.</param>
		public DoorStatusChangedTrigger(ISelector<IMyDoor> door, bool eager = true, bool raw = false)
		{
			_door = door.GetBlock();
			_doorStatus = GetStatus();
			_eager = eager;
			_raw = raw;
		}

		public override void Update()
		{
			var status = GetStatus();
			if (status != _doorStatus)
			{
				_doorStatus = status;
				Run(_doorStatus);
			}
		}

		private DoorStatus GetStatus()
		{
			var status = _door.Status;
			if (_raw) return status;
			if (status == DoorStatus.Opening) return _eager ? DoorStatus.Open : DoorStatus.Closed;
			if (status == DoorStatus.Closing) return _eager ? DoorStatus.Closed : DoorStatus.Open;
			return status;
		}
	}
}
