using System;

namespace ReversePolishNotationFn
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleKey response;
			ICalculator calculator = new RpnCalculator();

			do
			{
				Console.WriteLine("Введите инфиксное выражение:");
				var inputExpression = Console.ReadLine();

				try
				{
					var result = calculator.CalculateExpression(inputExpression);
					Console.WriteLine("Обратная польская запись:");
					Console.WriteLine(result);
				}
				catch (Exception e)
				{
					Console.WriteLine("Необработанной исключение ({0})", e);
					Console.WriteLine();
				}

				do
				{
					Console.Write("Желаете повторить вычисление? [y/n]: ");
					response = Console.ReadKey(false).Key;
					Console.WriteLine();
				} while (response != ConsoleKey.Y && response != ConsoleKey.N);

				Console.WriteLine();
			} while (response == ConsoleKey.Y);
		}
	}
}
