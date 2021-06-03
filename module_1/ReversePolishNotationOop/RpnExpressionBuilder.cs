using System;

namespace ReversePolishNotationOop
{
	public class RpnExpressionBuilder
	{
		private static char OpeningBracket = '(';
		private static char ClosingBracket = ')';

		/// <summary>
		/// Помтроить выражение в обратной польской нотации
		/// </summary>
		/// <param name="expression"></param>
		/// <returns>Выражение в обратной польской нотации</returns>
		public string BuildExpression(string expression)
		{
			var inputExpression = expression?.Replace(" ", "");
			inputExpression = InvertUnaryOperator(inputExpression);

			var outputExpression = "";
			var stack = new Stack<string>();

			for (int i = 0; i < inputExpression.Length; i++)
			{
				if (char.IsNumber(inputExpression[i]))
				{
					while (!IsOperator(inputExpression[i]) && inputExpression[i] != ClosingBracket)
					{
						outputExpression += inputExpression[i];
						i++;

						if (i == inputExpression.Length)
							break;
					}
					outputExpression += " ";
					i--;
				}
				else if (inputExpression[i] == OpeningBracket)
				{
					stack.Push(inputExpression[i].ToString());
				}
				else if (inputExpression[i] == ClosingBracket)
				{
					outputExpression += BuildBrackets(stack);
				}
				else if (IsOperator(inputExpression[i]))
				{
					outputExpression += BuildOperator(stack, inputExpression[i]);
				}
				else
					throw new InvalidOperationException("Unknown lexeme: " + inputExpression[i]);
			}

			outputExpression += BuildEndingOperators(stack);

			return outputExpression;
		}

		/// <summary>
		/// Является ли символ оператором
		/// </summary>
		/// <param name="lexeme">Символ</param>
		/// <returns>True, если является иначе, False</returns>
		public static bool IsOperator(char lexeme)
		{
			char[] calculationOperators = { '+', '-', '*', '/' };

			for (int i = 0; i < calculationOperators.Length; i++)
			{
				if (calculationOperators[i] == lexeme)
					return true;
			}

			return false;
		}

		string BuildBrackets(Stack<string> stack)
		{
			var outputExpression = "";
			var openingBracketFound = false;

			while (!stack.IsEmpty())
			{
				char stackOperator = char.Parse(stack.Pop());
				if (stackOperator == OpeningBracket)
				{
					openingBracketFound = true;
					break;
				}

				outputExpression += stackOperator;
			}

			if (!openingBracketFound)
				throw new InvalidOperationException("An unexpected closing bracket.");

			return outputExpression;
		}

		string BuildOperator(Stack<string> stack, char lexeme)
		{
			string outputExpression = "";
			int operatorPriority = GetOperatorPriority(lexeme);

			while (!stack.IsEmpty())
			{
				char stackOperator = char.Parse(stack.Peek());
				if (stackOperator == OpeningBracket)
					break;

				int stackOperatorPriority = GetOperatorPriority(stackOperator);
				if (stackOperatorPriority < operatorPriority)
					break;

				outputExpression += stack.Pop();
			}

			stack.Push(lexeme.ToString());

			return outputExpression;
		}

		string BuildEndingOperators(Stack<string> stack)
		{
			string outputExpression = "";

			while (!stack.IsEmpty())
			{
				char operatorToken = char.Parse(stack.Pop());
				if (operatorToken == OpeningBracket)
					throw new InvalidOperationException("A redundant opening bracket");

				outputExpression += operatorToken;
			}

			return outputExpression;
		}
		
		int GetOperatorPriority(char token)
		{
			switch (token)
			{
				case '+': return 1;
				case '-': return 1;
				case '*': return 2;
				case '/': return 2;
				default:
					throw new InvalidOperationException("An unexpected action for the operator: " + token);
			}
		}

		string InvertUnaryOperator(string input)
		{
			string output = "";

			for (int i = 0; i < input.Length; i++)
			{
				string item = input[i].ToString();
				if (IsOperator(input[i]))
				{
					if (i == 0 || input[i - 1] == OpeningBracket)
					{
						item = "0" + item;
					}
				}

				output += item;
			}

			return output;
		}
	}
}
