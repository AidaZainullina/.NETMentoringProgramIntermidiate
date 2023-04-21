using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining.Classes
{
	/// <summary>
	/// Tasks class
	/// </summary>
	public class TasksClass
	{
		private readonly int _arrayLength;

		public TasksClass(int arrayLength)
		{
			_arrayLength = arrayLength;
		}

		/// <summary>
		/// Creates N tasks where N equals taskAmount value
		/// </summary>
		public void Operations()
		{
			// create a task to generate an array of 10 random integers
			var arrayClass = new ArrayClass(_arrayLength);
			var generateArrayTask = Task.Factory.StartNew(() => arrayClass.GenerateArray());

			// create a task to multiply the array with a random integer
			var multiplyArrayTask = generateArrayTask.ContinueWith(prevTask =>
				arrayClass.MultipliesArrayWithRandomInteger(prevTask.Result));

			// create a task to sort the array in ascending order
			var sortArrayTask = multiplyArrayTask.ContinueWith(prevTask => arrayClass.SortAscending(prevTask.Result));

			// create a task to calculate the average value of the array
			var calculateAverageTask =
				sortArrayTask.ContinueWith(prevTask => arrayClass.CalculateAverage(prevTask.Result));

			// wait for the last task to complete before exiting
			calculateAverageTask.Wait();
		}
	}
}
