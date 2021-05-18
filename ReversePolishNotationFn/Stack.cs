using System;

namespace ReversePolishNotationFn
{
	public class Stack<T>
	{
		private int _size = 16;
		private int _count;
		private T[] _stack;

		public int Count => _count;

		public Stack()
		{
			_stack = new T[_size];
		}

		/// <summary>
		/// Add item to stack
		/// </summary>
		/// <param name="item">Item</param>
		public void Push(T item)
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
		public T Pop()
		{
			if (IsEmpty())
				throw new InvalidOperationException("Stack is empty.");

			var item = _stack[--_count];
			_stack = Resize(_stack, _size, _count);

			return item;
		}

		/// <summary>
		/// Extract item from stack by predicate.Throws an error if it doesn't satisfy the predicate
		/// </summary>
		/// <param name="predicate">Predicate extract</param>
		/// <returns>Top item</returns>
		public T Pop(Predicate<T> predicate)
		{
			if (!predicate(Peek()))
				throw new InvalidOperationException("An unexpected lexeme: " + Peek());

			return Pop();
		}

		/// <summary>
		/// Extract items until stop predicate 
		/// </summary>
		/// <param name="stopPredicate">Stop predicate</param>
		/// <returns>Top items</returns>
		public T[] Pull(Predicate<T> stopPredicate)
		{
			return Pull(stopPredicate, false);
		}

		/// <summary>
		/// Extract items until stop predicate 
		/// </summary>
		/// <param name="stopPredicate">Stop predicate</param>
		/// <param name="throwException">Throw an exception if a stop predicate reached</param>
		/// <returns>Top items</returns>
		public T[] Pull(Predicate<T> stopPredicate, bool throwException)
		{
			var stack = new Stack<T>();
			while (!IsEmpty())
			{
				if (stopPredicate(Peek()))
					if (throwException)
						throw new InvalidOperationException("An unexpected lexeme: " + Peek());
					else
						break;

				stack.Push(Pop());
			}

			var result = new T[stack.Count];
			for (var i = 0; i < result.Length; i++)
			{
				result[i] = stack.Pop();
			}

			return result;
		}

		/// <summary>
		/// Fetch items until stop predicate 
		/// </summary>
		/// <param name="stopPredicate">Stop predicate</param>
		/// <param name="throwException">Throw an exception if a stop predicate not reached</param>
		/// <returns>Top items</returns>
		public T[] Fetch(Predicate<T> stopPredicate, bool throwException)
		{
			var stack = new Stack<T>();
			while (!IsEmpty())
			{
				var lexeme = Pop();
				if (stopPredicate(lexeme))
					break;

				stack.Push(lexeme);

				if(throwException && IsEmpty())
					throw new InvalidOperationException("Stop predicate not reached. Last lexeme: " + lexeme);
			}

			var result = new T[stack.Count];
			for (var i = 0; i < result.Length; i++)
			{
				result[i] = stack.Pop();
			}

			return result;
		}

		/// <summary>
		/// Get top item from stack
		/// </summary>
		/// <returns>Top item</returns>
		public T Peek()
		{
			if (IsEmpty())
				throw new InvalidOperationException("Stack is empty.");

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
		private T[] Resize(T[] oldArray, int newSize, int moveItemsCount)
		{
			var newArray = new T[newSize];

			for (int i = 0; i < moveItemsCount; i++)
				newArray[i] = oldArray[i];

			return newArray;
		}
	}
}