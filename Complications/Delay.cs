namespace IngameScript.Complications
{
	class Delay : Complication
	{
		private int _delay;

		public Delay(int delay)
		{
			_delay = delay;
		}

		public override void Execute()
		{
			Firmware.Instance.TimingManager.SetTimeout((delta) => Run(), _delay);
		}
	}
}
