/*
* Study the code of this application to calculate the sum of integers from 0 to N, and then
* change the application code so that the following requirements are met:
* 1. The calculation must be performed asynchronously.
* 2. N is set by the user from the console. The user has the right to make a new boundary in the calculation process,
* which should lead to the restart of the calculation.
* 3. When restarting the calculation, the application should continue working without any failures.
*/

using System;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwait.Task1.CancellationTokens.Interfaces;

namespace AsyncAwait.Task1.CancellationTokens;

class Program
{
	private readonly ICalculator _calculator;

	public Program(ICalculator calculator)
	{
		_calculator = calculator;
	}

    /// <summary>
    /// The Main method should not be changed at all.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
		Console.WriteLine("Mentoring program L2. Async/await.V1. Task 1");
        Console.WriteLine("Calculating the sum of integers from 0 to N.");
        Console.WriteLine("Use 'q' key to exit...");
        Console.WriteLine();

        Console.WriteLine("Enter N: ");

        var input = Console.ReadLine();
        while (input?.Trim().ToUpper() != "Q")
        {
            if (int.TryParse(input, out var n))
			{
				CalculateSumAsync(n);
            }
            else
            {
                Console.WriteLine($"Invalid integer: '{input}'. Please try again.");
                Console.WriteLine("Enter N: ");
            }

            input = Console.ReadLine();
        }

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }

    private static async Task CalculateSumAsync(int n)
    {
	    var calculator = new Calculator();
	    var program = new Program(calculator);
		var cts = new CancellationTokenSource();
		var token = cts.Token;

		Console.WriteLine("Press X key to cancel...");
		var cancelTask = Task.Run(() =>
		{
            while (true)
			{
				if (Console.ReadKey().Key == ConsoleKey.Escape)
				{
                    Console.WriteLine("Task was cancelled");
					cts.Cancel();
				}
			}
		});

        try
        {
			var sum = await Task.Run(() => program._calculator.Calculate(n, token));
			Console.WriteLine($"Sum for {n} = {sum}.");
			Console.WriteLine();
		}
        catch ( OperationCanceledException ex )
		{
			Console.WriteLine($"Sum for {n} cancelled...");
		}
    }
}
