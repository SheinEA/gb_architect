using System;
using System.Linq;

namespace ReversePolishNotationFn
{
	class RpnCalculator : ICalculator
	{
		/// <inheritdoc />
		public string CalculateExpression(string expression)
		{
			var rpnExpression = BuildExpression(expression, IsOperator, GetOperatorPriority, InvertUnaryOperator);
			var result = EvaluateExpression(rpnExpression, IsOperator, Calculate);
			return rpnExpression.Replace(" ", "") + result;
		}

		double EvaluateExpression(string expression, IsOperatorHandler isOperator, CalculationHandler calculator)
		{
			var stack = new Stack<double>();

			for (var i = 0; i < expression.Length; i++)
			{
				if (char.IsNumber(expression[i]))
				{
					var number = string.Empty;
					while (expression[i].ToString() != " " && !isOperator(expression[i]))
					{
						number += expression[i];
						i++;

						if (i == expression.Length)
							break;
					}
					i--;
					stack.Push(double.Parse(number));
				}
				else if (isOperator(expression[i]))
				{
					var a = stack.Pop();
					var b = stack.Pop();
					stack.Push(calculator(expression[i], a, b));
				}
			}

			return !stack.IsEmpty() ? stack.Peek() : 0;
		}

		string BuildExpression(string expression, IsOperatorHandler isOperator, OperatorPriorityHandler priorityGetter, UnaryOperatorHandler unaryInverter)
		{
			var output = string.Empty;
			var stack = new Stack<string>();
			var input = unaryInverter(expression, isOperator);

			for (var i = 0; i < input.Length; i++)
			{
				if (char.IsNumber(input[i]))
				{
					while (!isOperator(input[i]) && input[i] != ')')
					{
						output += input[i];
						i++;

						if (i == input.Length)
							break;
					}
					i--;
					output += " ";
				}
				else if (input[i] == '(')
				{
					stack.Push(input[i].ToString());
				}
				else if (input[i] == ')')
				{
					output += string.Join("", stack.Fetch(x => x == "(", true).Reverse());
				}
				else if (isOperator(input[i]))
				{
					var priorityOperator = priorityGetter(input[i]);
					output += string.Join("", stack.Pull(x => x == "(" || priorityGetter(char.Parse(x)) < priorityOperator));
					stack.Push(input[i].ToString());
				}
				else
					throw new InvalidOperationException("Unknown lexeme: " + input[i]);
			}

			var endingOperators = string.Join("", stack.Pull(i => i == "(", true).Reverse());

			return output + endingOperators;
		}

		bool IsOperator(char lexeme) => new[] { '+', '-', '*', '/' }.Contains(lexeme);

		double Calculate(char operation, double operand1, double operand2)
		{
			switch (operation)
			{
				case '+': return operand2 + operand1;
				case '-': return operand2 - operand1;
				case '*': return operand2 * operand1;
				case '/': return operand2 / operand1;
				default:
					throw new InvalidOperationException("An unexpected action for the operator: " + operation);

			}
		}

		int GetOperatorPriority(char operatorLexeme)
		{
			switch (operatorLexeme)
			{
				case '+': return 1;
				case '-': return 1;
				case '*': return 2;
				case '/': return 2;
				default:
					throw new InvalidOperationException("An unexpected action for the operator: " + operatorLexeme);
			}
		}

		string InvertUnaryOperator(string input, IsOperatorHandler isOperator)
		{
			var inputExpression = input?.Replace(" ", "") ?? "";
			return inputExpression
				.Select((o, i) => isOperator(o) && (i == 0 || inputExpression[i - 1] == '(') ? "0" + o : "" + o)
				.Aggregate("", (current, item) => current + item);
		}
	}
}