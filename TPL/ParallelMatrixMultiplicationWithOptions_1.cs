﻿using System.Threading.Tasks;

namespace TPL
{
    public class ParallelMatrixMultiplicationWithOptions_1
    {
        public static Matrix MultiplyMatrices(Matrix matrix1, Matrix matrix2, int maxDegreeOfParallelism)
        {
            if (matrix1.Col != matrix2.Row)
            {
                return null;
            }

            Matrix matrixResult = new Matrix(matrix1.Row, matrix2.Col);

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = maxDegreeOfParallelism;

            Parallel.For(0, matrix1.Row, options, i =>
            {
                for (int j = 0; j < matrix2.Col; j++)
                {
                    int item = 0;

                    for (int k = 0; k < matrix2.Row; k++)
                    {
                        item += matrix1[i, k] * matrix2[k, j];
                    }

                    matrixResult[i, j] = item;
                }
            });

            return matrixResult;
        }
    }
}
