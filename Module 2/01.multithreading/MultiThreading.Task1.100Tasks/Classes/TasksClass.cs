using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Task1._100Tasks.Classes
{
	/// <summary>
	/// Tasks class
	/// </summary>
	public class TasksClass
	{
		private readonly int _taskAmount;
		private readonly int _maxIterationsCount = 1000;

		public TasksClass(int taskAmount)
		{
			_taskAmount = taskAmount;
		}

		/// <summary>
		/// Creates N tasks where N equals taskAmount value
		/// </summary>
		public void CreateTasks()
		{
			var taskList = new Task[_taskAmount];
			var printResultClass = new PrintResultClass(_maxIterationsCount);
			for (var i = 0; i < taskList.Length; i++)
			{
				int taskNumber = i;
				taskList[i] = Task.Run(() => printResultClass.PrintMessage(taskNumber));
			}

			Task.WaitAll(taskList.ToArray());
		}
	}
}
