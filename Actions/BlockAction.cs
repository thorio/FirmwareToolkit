using System.Collections.Generic;

namespace IngameScript
{
	partial class Program
	{
		abstract class BlockAction<T> : IAction
		{
			protected readonly ISelector<T> _selector;
			public BlockAction(ISelector<T> selector)
			{
				_selector = selector;
			}

			public void Execute()
			{
				Execute(_selector.GetBlocks());
			}

			protected abstract void Execute(IEnumerable<T> blocks);
		}
	}
}
