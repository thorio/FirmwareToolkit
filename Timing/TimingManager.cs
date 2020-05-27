using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;

namespace IngameScript.Timing
{
	class TimingManager
	{
		private List<Timer> _timers;
		private IMyGridProgramRuntimeInfo _runtimeInfo;
		private double _time;

		public TimingManager(IMyGridProgramRuntimeInfo runtimeInfo)
		{
			_timers = new List<Timer>();
			_runtimeInfo = runtimeInfo;
			_time = 0;
		}

		public void Update()
		{
			_time += _runtimeInfo.TimeSinceLastRun.TotalMilliseconds;
			foreach (var timer in _timers)
			{
				if (_time >= timer.Target)
				{
					timer.Callback(_time - timer.Target);
					if (timer.Interval.HasValue)
					{
						timer.Target += timer.Interval.Value;
					}
				}
			}
			// clear expired timeouts
			_timers.RemoveAll((t) => !t.Interval.HasValue && _time > t.Target);
		}

		/// <summary>
		/// The Callback is called after the specified interval has elapsed
		/// </summary>
		/// <param name="time">Time in milliseconds</param>
		/// <param name="callback">Parameter: delta between requested interval and actual time passed</param>
		public Timer SetTimeout(Action<double> callback, int time)
		{
			var timer = new Timer(callback);
			timer.Target = _time + time;
			_timers.Add(timer);
			return timer;
		}

		/// <summary>
		/// The Callback is called each time the specified interval elapses
		/// </summary>
		/// <param name="time">Time in milliseconds</param>
		/// <param name="callback">Parameter: delta between requested interval and actual time passed</param>
		public Timer SetInterval(Action<double> callback, int time)
		{
			var timer = new Timer(callback, time);
			timer.Target = _time + time;
			_timers.Add(timer);
			return timer;
		}

		/// <summary>
		/// Cancels the Timeout or Interval
		/// </summary>
		public bool Clear(Timer timer) =>
			_timers.Remove(timer);
	}
}
