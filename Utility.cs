using IngameScript.Selectors;
using Sandbox.ModAPI.Ingame;

namespace IngameScript
{
	partial class Program
	{
		TagSelector<IMyTerminalBlock> Tag(string tag) => Tag<IMyTerminalBlock>(tag);
		TagSelector<T> Tag<T>(string tag) where T : IMyTerminalBlock => new TagSelector<T>(tag);
		GroupSelector<IMyTerminalBlock> Group(string name) => Group<IMyTerminalBlock>(name);
		GroupSelector<T> Group<T>(string name) where T : IMyTerminalBlock => new GroupSelector<T>(name);
		NameSelector<IMyTerminalBlock> Name(string name) => Name<IMyTerminalBlock>(name);
		NameSelector<T> Name<T>(string name) where T : IMyTerminalBlock => new NameSelector<T>(name);
	}
}
