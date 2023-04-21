/*
 * 1.	Write a program, which creates an array of 100 Tasks, runs them and waits all of them are not finished.
 * Each Task should iterate from 1 to 1000 and print into the console the following string:
 * “Task #0 – {iteration number}”.
 */
using MultiThreading.Task1._100Tasks.Classes;
using System;

namespace MultiThreading.Task1._100Tasks
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(".Net Mentoring Program. Multi threading V1.");
			Console.WriteLine("1.	Write a program, which creates an array of 100 Tasks, runs them and waits all of them are not finished.");
			Console.WriteLine("Each Task should iterate from 1 to 1000 and print into the console the following string:");
			Console.WriteLine("“Task #0 – {iteration number}”.");
			Console.WriteLine();

			HundredTasks();

			Console.ReadLine();
		}

		static void HundredTasks()
		{
			var tasksClass = new TasksClass(100);
			tasksClass.CreateTasks();
		}
	}
}
