using IngameScript.Actions;
using IngameScript.Selectors;
using IngameScript.Triggers;
using Sandbox.ModAPI.Ingame;
using SpaceEngineers.Game.ModAPI.Ingame;

namespace IngameScript.Constructs
{
	/// <summary>
	/// Manages an airlock consisting of two doors and a vent.
	/// Turn the vent off to disable the airlock and allow both doors to be opened.
	/// </summary>
	class AirlockConstruct : Construct
	{
		private IMyDoor _innerDoor;
		private IMyDoor _outerDoor;
		private IMyAirVent _vent;
		private VentStatus _status;
		private bool _enabled;

		public AirlockConstruct(ISelector<IMyDoor> innerDoor, ISelector<IMyDoor> outerDoor, ISelector<IMyAirVent> vent)
		{
			_innerDoor = innerDoor.GetBlock();
			_outerDoor = outerDoor.GetBlock();
			_vent = vent.GetBlock();
			_status = _vent.Status;
			_enabled = _vent.Enabled;
			CycleAction = new ScriptableAction(() => Cycle());
			PressurizeAction = new ScriptableAction(() => Cycle(true));
			DepressurizeAction = new ScriptableAction(() => Cycle(false));
			_triggers.Add(new IntervalTrigger(300).Then(new ScriptableAction(Update)));
		}

		public ScriptableAction CycleAction { get; }
		public ScriptableAction PressurizeAction { get; }
		public ScriptableAction DepressurizeAction { get; }
		private bool AirlockHasPressure => _vent.Status == VentStatus.Pressurized;

		/// <summary>
		/// Registers Cycle{<paramref name="airlockName"/>},
		/// Pressurize{<paramref name="airlockName"/>} and
		/// Depressurize{<paramref name="airlockName"/>}
		/// <see cref="ArgumentTrigger"/>s
		/// </summary>
		public AirlockConstruct AddArgumentTriggers(string airlockName)
		{
			_triggers.Add(new ArgumentTrigger($"Cycle{airlockName}").Then(CycleAction));
			_triggers.Add(new ArgumentTrigger($"Pressurize{airlockName}").Then(PressurizeAction));
			_triggers.Add(new ArgumentTrigger($"Depressurize{airlockName}").Then(DepressurizeAction));
			return this;
		}

		private void Cycle(bool? pressurize = null)
		{
			if (_status == VentStatus.Depressurizing || _status == VentStatus.Pressurizing || pressurize == AirlockHasPressure || !_enabled) return;
			if (pressurize ?? !AirlockHasPressure)
			{
				_status = VentStatus.Pressurizing;
				_outerDoor.CloseDoor();
			}
			else
			{
				_status = VentStatus.Depressurizing;
				_innerDoor.CloseDoor();
			}
		}

		private void Update()
		{
			UpdateEnabled();
			if (_status == VentStatus.Pressurizing)
			{
				PressurizeSequence();
			}
			else if (_status == VentStatus.Depressurizing)
			{
				DepressurizeSequence();
			}
		}

		private void UpdateEnabled()
		{
			if (_vent.Enabled != _enabled)
			{
				_enabled = _vent.Enabled;
				if (_enabled)
				{
					_outerDoor.CloseDoor();
					_status = VentStatus.Pressurizing;
				}
				else
				{
					_innerDoor.Enabled = _outerDoor.Enabled = true;
				}
			}
		}

		private void PressurizeSequence()
		{
			if (_vent.Status == VentStatus.Pressurized)
			{
				_outerDoor.Enabled = false;
				_innerDoor.Enabled = true;
				_innerDoor.OpenDoor();
				_status = VentStatus.Pressurized;
			}
			else if (_outerDoor.Status == DoorStatus.Closed)
			{
				_outerDoor.Enabled = _vent.Depressurize = false;
			}
		}

		private void DepressurizeSequence()
		{
			if (_vent.GetOxygenLevel() == 0)
			{
				_outerDoor.Enabled = true;
				_outerDoor.OpenDoor();
				_status = VentStatus.Depressurized;
			}
			else if (_innerDoor.Status == DoorStatus.Closed)
			{
				_innerDoor.Enabled = false;
				_vent.Depressurize = true;
			}
		}
	}
}
