using System;

namespace ReversePolishNotationOop
{
	public class Stack<T>
	{
		private int _size = 16;
		private int _count;
		private T[] _stack;

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
				throw new InvalidOperationException("Stack is empty");

			var item = _stack[--_count];
			_stack = Resize(_stack, _size, _count);

			return item;
		}

		/// <summary>
		/// Get top item from stack
		/// </summary>
		/// <returns>Top item</returns>
		public T Peek()
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
		private T[] Resize(T[] oldArray, int newSize, int moveItemsCount)
		{
			var newArray = new T[newSize];

			for (int i = 0; i < moveItemsCount; i++)
				newArray[i] = oldArray[i];

			return newArray;
		}
	}
}
