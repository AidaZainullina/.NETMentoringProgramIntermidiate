using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Task1.CancellationTokens;

internal static class Calculator
{
    // todo: change this method to support cancellation token
    public static long Calculate(int n, CancellationToken token)
	{
		long sum = 0;
		while (!token.IsCancellationRequested)
		{
			Console.WriteLine("Current thread ID: {0}", Thread.CurrentThread.ManagedThreadId);
			for (var i = 0; i < n; i++)
			{
				if (token.IsCancellationRequested)
				{
					Console.WriteLine("Canceld inside if");
					token.ThrowIfCancellationRequested();
				}
				
				// i + 1 is to allow 2147483647 (Max(Int32)) 
				sum = sum + (i + 1);
				Task.Delay(10000);
			}

			Console.WriteLine("sum: {0}", sum);
			return sum;
		}


		Console.WriteLine("Canceld inside if");
		token.ThrowIfCancellationRequested();
		return 0;
	}
}
