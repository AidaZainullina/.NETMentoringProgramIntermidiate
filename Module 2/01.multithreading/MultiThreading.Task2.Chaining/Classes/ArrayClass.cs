using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining.Classes
{
	public class ArrayClass
	{
		private readonly int _arrayLength;

		public ArrayClass(int arrayLength)
		{
			_arrayLength = arrayLength;
		}

		/// <summary>
		/// Creates N tasks where N equals taskAmount value
		/// </summary>
		public int[] GenerateArray()
		{
			Console.WriteLine("Task 1. Creates an array of 10 random integers.");
			Console.WriteLine("Generated Array: ");
			Random random = new Random();
			int[] arr = new int[_arrayLength];
			for (int i = 0; i < _arrayLength; i++)
			{
				arr[i] = random.Next(9);
				Console.Write(arr[i] + " ");
			}

			WriteTwoEmptyLines();

			return arr;
		}

		/// <summary>
		/// Multiplies this array with another random integer
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public int[] MultipliesArrayWithRandomInteger(int[] arr)
		{
			Random rand = new Random();
			int factor = rand.Next(1, 11);
			Console.WriteLine("Task 2. Multiplies array with another random integer.");
			Console.WriteLine("Previous array: ");
			Console.WriteLine("{0}", string.Join(", ", arr));
			Console.WriteLine("Random integer: {0}", factor);
			Console.WriteLine("Updated array of values: ");
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] *= factor;
				Console.Write(arr[i] + " ");
			}

			WriteTwoEmptyLines();
			return arr;
		}

		/// <summary>
		/// Sorts this array by ascending
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public int[] SortAscending(int[] arr)
		{
			Console.WriteLine("Task 3. Sorts this array by ascending.");
			Array.Sort(arr);
			Console.WriteLine("Sorted Array:");

			foreach (int value in arr)
			{
				Console.Write(value + " ");
			}

			WriteTwoEmptyLines();
			return arr;
		}

		/// <summary>
		/// Calculates the average value. All this tasks should print the values to console
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public double CalculateAverage(int[] arr)
		{
			Console.WriteLine("Task 4. Calculates the average value.");
			double sum = 0;

			for (int i = 0; i < arr.Length; i++)
			{
				sum += arr[i];
			}

			var average = sum / arr.Length;

			// print the calculated average
			Console.WriteLine("Average: " + average);
			WriteTwoEmptyLines();
			return average;
		}

		private void WriteTwoEmptyLines()
		{
			Console.WriteLine();
			Console.WriteLine();
		}
	}
}
