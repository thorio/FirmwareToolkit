namespace IngameScript.Triggers
{
	/// <summary>
	/// Triggers when the block is run with a matching argument
	/// </summary>
	class ArgumentTrigger : Trigger
	{
		private readonly string _exactMatch;
		private readonly System.Text.RegularExpressions.Regex _expression;

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
			if (_expression?.IsMatch(argument) == true || argument == _exactMatch)
			{
				Run();
			}
		}
	}
}
