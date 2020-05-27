namespace IngameScript.Actions
{
	interface IParametricAction<T>
	{
		void Execute(T parameter);
	}
}
