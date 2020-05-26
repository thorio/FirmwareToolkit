using System;

namespace IngameScript.Timing
{
	class Timer
	{
		public Timer(Action<double> callback, int? interval = null)
		{
			Callback = callback;
			Interval = interval;
		}

		public Action<double> Callback { get; }
		public double Target { get; set; }
		public int? Interval { get; }
	}
}
