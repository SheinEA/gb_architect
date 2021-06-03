using System;

namespace ReversePolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey response;
            RpnCalculator calculator = new RpnCalculator();

            do
            {
                Console.WriteLine("Введите инфиксное выражение:");
                string inputExpression = Console.ReadLine();

                try
                {
                    string rawExpression = calculator.BuildExpression(inputExpression);
                    double resultExpression = calculator.EvaluateExpression(rawExpression);

                    Console.WriteLine("Обратная польская запись:");
                    Console.WriteLine(rawExpression.Replace(" ", "") + resultExpression);
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

    class RpnCalculator
    {
        private static char OpeningBracket = '(';
        private static char ClosingBracket = ')';

        public string BuildExpression(string infixExpression)
        {
            string inputExpression = CleanWhiteSpaces(infixExpression);
            inputExpression = InvertUnaryOperator(inputExpression);

            string outputExpression = "";
            Stack stack = new Stack();

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

        public double EvaluateExpression(string rpnExpression)
        {
            double result = 0;
            Stack stack = new Stack();

            for (int i = 0; i < rpnExpression.Length; i++)
            {
                if (char.IsNumber(rpnExpression[i]))
                {
                    string number = string.Empty;

                    while (rpnExpression[i].ToString() != " " && !IsOperator(rpnExpression[i]))
                    {
                        number += rpnExpression[i];
                        i++;

                        if (i == rpnExpression.Length)
                            break;
                    }
                    stack.Push(number);
                    i--;
                }
                else if (IsOperator(rpnExpression[i]))
                {
                    double a = double.Parse(stack.Pop());
                    double b = double.Parse(stack.Pop());

                    switch (rpnExpression[i])
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                        default:
                            throw new InvalidOperationException("An unexpected action for the operator: " + rpnExpression[i]);

                    }

                    stack.Push(result.ToString("G"));
                }
            }

            return !stack.IsEmpty() ? double.Parse(stack.Peek()) : result;
        }

        string BuildBrackets(Stack stack)
        {
            string outputExpression = "";
            bool openingBracketFound = false;

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

        string BuildOperator(Stack stack, char lexeme)
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

        string BuildEndingOperators(Stack stack)
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

        bool IsOperator(char lexeme)
        {
            char[] calculationOperators = { '+', '-', '*', '/' };

            for (int i = 0; i < calculationOperators.Length; i++)
            {
                if (calculationOperators[i] == lexeme)
                    return true;
            }

            return false;
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

        string CleanWhiteSpaces(string input)
        {
            string output = input;

            if (output != null)
                output = output.Replace(" ", "");

            return output;
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

    class Stack
    {
        private int _size = 16;
        private int _count = 0;
        private string[] _stack;

        public Stack()
        {
            _stack = new string[_size];
        }

        /// <summary>
        /// Add item to stack
        /// </summary>
        /// <param name="item">Item</param>
        public void Push(string item)
        {
            if (_count == _size)
            {
                _size = _size + _size;
                _stack = Resize(_stack, _size, _count);
            }

            _stack[_count++] = item;
        }

        /// <summary>
        /// Extract item from stack
        /// </summary>
        /// <returns>Top item</returns>
        public string Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            string item = _stack[--_count];
            _stack = Resize(_stack, _size, _count);

            return item;
        }

        /// <summary>
        /// Get top item from stack
        /// </summary>
        /// <returns>Top item</returns>
        public string Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            return _stack[_count - 1];
        }

        /// <summary>
        /// Stack is empty
        /// </summary>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// Resize array with move items
        /// </summary>
        /// <param name="oldArray">Old array</param>
        /// <param name="newSize">Size for new array</param>
        /// <param name="moveItemsCount">Number of objects to move</param>
        /// <returns>New array</returns>
        private string[] Resize(string[] oldArray, int newSize, int moveItemsCount)
        {
            string[] newArray = new string[newSize];

            for (int i = 0; i < moveItemsCount; i++)
                newArray[i] = oldArray[i];

            return newArray;
        }
    }
}