/*
 * 5. Write a program which creates two threads and a shared collection:
 * the first one should add 10 elements into the collection and the second should print all elements
 * in the collection after each adding.
 * Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.
 */
using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiThreading.Task5.Threads.SharedCollection
{
    class Program
    {
		static List<int> sharedList = new List<int>();
		static readonly object lockObject = new object();

		static void Main()
		{
			Console.WriteLine("5. Write a program which creates two threads and a shared collection:");
			Console.WriteLine("the first one should add 10 elements into the collection and the second should print all elements in the collection after each adding.");
			Console.WriteLine("Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.");
			Console.WriteLine();

			Thread addThread = new Thread(AddElements);
			Thread printThread = new Thread(PrintElements);
			addThread.Start();
			printThread.Start();
			addThread.Join();
			printThread.Join();
		}

		static void AddElements()
		{
			for (int i = 1; i <= 10; i++)
			{
				lock (lockObject)
				{
					sharedList.Add(i);
				}
				Thread.Sleep(500); // simulate some work
			}
		}

		static void PrintElements()
		{
			List<int> copyOfList = new List<int>();
			while (true)
			{
				lock (lockObject)
				{
					copyOfList.AddRange(sharedList);
				}
				Console.WriteLine("[{0}]", string.Join(", ", copyOfList));
				if (copyOfList.Count == 10)
				{
					break;
				}
				copyOfList.Clear();
				Thread.Sleep(100); // simulate some work
			}
		}
	}
}

