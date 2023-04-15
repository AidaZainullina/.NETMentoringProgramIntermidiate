using System;
using System.Threading.Tasks;
using MultiThreading.Task3.MatrixMultiplier.Matrices;

namespace MultiThreading.Task3.MatrixMultiplier.Multipliers
{
    public class MatricesMultiplierParallel : IMatricesMultiplier
    {
        public IMatrix Multiply(IMatrix m1, IMatrix m2)
        {
	        long rowsM1 = m1.RowCount;
            long rowsM2 = m2.RowCount;
            long colM1 = m1.ColCount;
            long colM2 = m2.ColCount;
			
            var resultMatrix = new Matrix(m1.RowCount, m2.ColCount);

			Parallel.For(0, rowsM1, i =>
            {
	            for (int j = 0; j < colM2; j++)
	            {
		            long sum = 0;
		            for (int k = 0; k < colM1; k++)
		            {
			            sum += m1.GetElement(i, k) * m2.GetElement(k, j);
		            }
		            resultMatrix.SetElement(i, j, sum);
	            }
            });
			
			return resultMatrix;
        }
    }
}
