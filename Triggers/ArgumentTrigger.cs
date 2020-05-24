namespace IngameScript
{
	partial class Program
	{
		/// <summary>
		/// Triggers when the block is run with a matching argument
		/// </summary>
		class ArgumentTrigger : BaseTrigger
		{
			private string _exactMatch;
			private System.Text.RegularExpressions.Regex _expression;

			public ArgumentTrigger(string argument)
			{
				_exactMatch = argument;
			}

			public ArgumentTrigger(System.Text.RegularExpressions.Regex expression)
			{
				_expression = expression;
			}

			public void Update(string argument)
			{
				if (_expression?.IsMatch(argument) == true)
				{
					Trigger();
				}
				else if (argument == _exactMatch)
				{
					Trigger();
				}
			}
		}
	}
}
