using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreading.Task1._100Tasks.Classes
{
	/// <summary>
	/// PrintResultClass
	/// </summary>
	public class PrintResultClass
	{
		private readonly int _maxIterationsCount;

		public PrintResultClass(int maxIterationsCount)
		{
			_maxIterationsCount = maxIterationsCount;
		}

		/// <summary>
		/// Prints message into console
		/// </summary>
		/// <param name="firstNumber"></param>
		public void PrintMessage(int firstNumber)
		{
			for (int j = 1; j <= _maxIterationsCount; j++)
			{
				Console.WriteLine("Task #{0} - {1}", firstNumber, j);
			}
		}
	}
}
