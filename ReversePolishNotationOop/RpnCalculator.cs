using System;

namespace ReversePolishNotationOop
{
	class RpnCalculator : ICalculator
	{
		/// <inheritdoc />
		public string CalculateExpression(string expression)
		{
			var expressionBuilder = new RpnExpressionBuilder();
 		    var rpnExpression = expressionBuilder.BuildExpression(expression);
			var result = EvaluateExpression(rpnExpression);
			return rpnExpression.Replace(" ", "") + result;
		}

		private double EvaluateExpression(string expression)
		{
			double result = 0;
			var stack = new Stack<double>();

			for (int i = 0; i < expression.Length; i++)
			{
				if (char.IsNumber(expression[i]))
				{
					var number = string.Empty;
					while (expression[i].ToString() != " " && !RpnExpressionBuilder.IsOperator(expression[i]))
					{
						number += expression[i];
						i++;

						if (i == expression.Length)
							break;
					}
					stack.Push(double.Parse(number));
					i--;
				}
				else if (RpnExpressionBuilder.IsOperator(expression[i]))
				{
					var a = stack.Pop();
					var b = stack.Pop();

					switch (expression[i])
					{
						case '+': result = b + a; break;
						case '-': result = b - a; break;
						case '*': result = b * a; break;
						case '/': result = b / a; break;
						default:
							throw new InvalidOperationException("An unexpected action for the operator: " + expression[i]);

					}

					stack.Push(result);
				}
			}

			return !stack.IsEmpty() ? stack.Peek() : result;
		}
	}
}
