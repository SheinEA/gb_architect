namespace ReversePolishNotationOop
{
	public interface ICalculator
	{
		/// <summary>
		/// Получить строку выражения и результат вычисления
		/// </summary>
		/// <param name="expression">Выражение</param>
		/// <returns>Строка выражения и результат вычисления</returns>
		string CalculateExpression(string expression);
	}
}
