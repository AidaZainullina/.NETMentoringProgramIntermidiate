using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Task1.CancellationTokens.Interfaces
{
	public interface ICalcOperations
	{
		long Calculate(int n, CancellationToken token);
	}
}
