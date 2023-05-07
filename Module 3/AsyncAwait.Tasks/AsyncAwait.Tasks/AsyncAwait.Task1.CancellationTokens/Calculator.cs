using System;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwait.Task1.CancellationTokens.Interfaces;

namespace AsyncAwait.Task1.CancellationTokens;

public class CalcOperations : ICalcOperations
{
    public long Calculate(int n, CancellationToken token)
	{
		long sum = 0;
		while (!token.IsCancellationRequested)
		{
			Console.WriteLine("Current thread ID: {0}", Thread.CurrentThread.ManagedThreadId);
			for (var i = 0; i < n; i++)
			{
				if (token.IsCancellationRequested)
				{
					token.ThrowIfCancellationRequested();
				}
				
				// i + 1 is to allow 2147483647 (Max(Int32)) 
				sum = sum + (i + 1);
				Task.Delay(10000);
			}

			Console.WriteLine("The sum is: {0}", sum);
			return sum;
		}

		token.ThrowIfCancellationRequested();
		return 0;
	}
}
