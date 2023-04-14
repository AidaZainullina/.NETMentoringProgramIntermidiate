/*
 * 4.	Write a program which recursively creates 10 threads.
 * Each thread should be with the same body and receive a state with integer number, decrement it,
 * print and pass as a state into the newly created thread.
 * Use Thread class for this task and Join for waiting threads.
 * 
 * Implement all of the following options:
 * - a) Use Thread class for this task and Join for waiting threads.
 * - b) ThreadPool class for this task and Semaphore for waiting threads.
 */

using System;
using System.Threading;

namespace MultiThreading.Task4.Threads.Join
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("4.	Write a program which recursively creates 10 threads.");
            Console.WriteLine("Each thread should be with the same body and receive a state with integer number, decrement it, print and pass as a state into the newly created thread.");
            Console.WriteLine("Implement all of the following options:");
            Console.WriteLine();
            Console.WriteLine("- a) Use Thread class for this task and Join for waiting threads.");
            Console.WriteLine("- b) ThreadPool class for this task and Semaphore for waiting threads.");

            Console.WriteLine();
            Console.WriteLine("Using Thread class with Join:");

            // create the first thread and start it
            Thread thread = new Thread(DecrementState);
            thread.Start(10);

            // join the first thread and wait for it to finish
            thread.Join();

            Console.WriteLine("Using ThreadPool class with Semaphore:");

            // create a semaphore to control access to the thread pool
            Semaphore semaphore = new Semaphore(0, 10);

            // queue the first thread to the thread pool
            ThreadPool.QueueUserWorkItem(DecrementStateWithSemaphore, new object[] { 10, semaphore });

            // wait for all the threads to finish
            for (int i = 0; i < 10; i++)
            {
	            semaphore.WaitOne();
            }
        }

        static void DecrementState(object state)
        {
	        int value = (int)state;
	        Console.WriteLine("Thread {0} is running. State = {1}", Thread.CurrentThread.ManagedThreadId, value);
	        if (value > 0)
	        {
		        Thread thread = new Thread(DecrementState);
		        thread.Start(value - 1);
		        thread.Join();
	        }
        }

        static void DecrementStateWithSemaphore(object state)
        {
	        object[] data = (object[])state;
	        int value = (int)data[0];
	        Semaphore semaphore = (Semaphore)data[1];
	        Console.WriteLine("Thread {0} is running. State = {1}", Thread.CurrentThread.ManagedThreadId, value);
	        if (value > 0)
	        {
		        ThreadPool.QueueUserWorkItem(DecrementStateWithSemaphore, new object[] { value - 1, semaphore });
	        }
	        semaphore.Release();
        }
	}
}
