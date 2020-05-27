namespace IngameScript.Triggers
{
	class IntervalTrigger : Trigger
	{
		public IntervalTrigger(int interval)
		{
			Firmware.Instance.TimingManager.SetInterval((delta) => Run(), interval);
		}
	}
}
