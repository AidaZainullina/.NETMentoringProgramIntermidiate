/*
 * 2.	Write a program, which creates a chain of four Tasks.
 * First Task – creates an array of 10 random integer.
 * Second Task – multiplies this array with another random integer.
 * Third Task – sorts this array by ascending.
 * Fourth Task – calculates the average value. All this tasks should print the values to console.
 */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining
{
    class Program
    {
	    static void Main(string[] args)
        {
            Console.WriteLine(".Net Mentoring Program. MultiThreading V1 ");
            Console.WriteLine("2.	Write a program, which creates a chain of four Tasks.");
            Console.WriteLine("First Task – creates an array of 10 random integer.");
            Console.WriteLine("Second Task – multiplies this array with another random integer.");
            Console.WriteLine("Third Task – sorts this array by ascending.");
            Console.WriteLine("Fourth Task – calculates the average value. All this tasks should print the values to console");
            Console.WriteLine();

            // create a task to generate an array of 10 random integers
			Task<int[]> generateArrayTask = (Task<int[]>)Task.Factory.StartNew(() => GenerateIntArray(10));

			// create a task to multiply the array with a random integer
			Random rand = new Random();
			int factor = rand.Next(1, 11);
			Task<int[]> multiplyArrayTask = generateArrayTask.ContinueWith(prevTask =>
				MultipliesArrayWithRandomInteger(prevTask.Result, factor));

			// create a task to sort the array in ascending order
			Task<int[]> sortArrayTask = multiplyArrayTask.ContinueWith(prevTask => SortAscending(prevTask.Result));

			// create a task to calculate the average value of the array
			Task<double> calculateAverageTask =
				sortArrayTask.ContinueWith(prevTask => CalculateAverage(prevTask.Result));

			// wait for the last task to complete before exiting
			calculateAverageTask.Wait();
		}

	    static int[] GenerateIntArray(int length)
		{
			WriteTwoEmptyLines();
			Console.WriteLine("Task 1. Creates an array of 10 random integers.");
			Console.WriteLine("Generated Array: ");
			Random random = new Random();
		    int[] arr = new int[length];
		    for (int i = 0; i < length; i++)
		    {
			    arr[i] = random.Next(9);
			    Console.Write(arr[i] + " ");
			}
			return arr;
	    }

	    static int[] MultipliesArrayWithRandomInteger(int[] arr, int factor)
		{
			WriteTwoEmptyLines();
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

			return arr;
        }

        static int[] SortAscending(int[] arr)
		{
			WriteTwoEmptyLines();
			Console.WriteLine("Task 3. Sorts this array by ascending.");
			Array.Sort(arr);
            Console.WriteLine("Sorted Array:");

            foreach (int value in arr)
            {
	            Console.Write(value + " ");
            }

            return arr;
        }

        static double CalculateAverage(int[] arr)
        {
	        WriteTwoEmptyLines();
			Console.WriteLine("Task 4. Calculates the average value.");
			double sum = 0;

	        for (int i = 0; i < arr.Length; i++)
	        {
		        sum += arr[i];
	        }

	        var average =  sum / arr.Length;

	        // print the calculated average
	        Console.WriteLine("Average: " + average);

	        return average;
        }

        static void WriteTwoEmptyLines()
        {
	        Console.WriteLine();
	        Console.WriteLine();
		}
	}
}
