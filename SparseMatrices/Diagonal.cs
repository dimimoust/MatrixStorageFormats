using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    public class Diagonal
    {
        public double[] DiagonalMatrices(double[,] matrix)
        {
            int length = matrix.GetLength(0);
            double[] array = new double[length];

            int i = 0;
            int j = 0;
            while (i == j && i < length)
            {
                array[i] = matrix[i, j];
                i++;
                j++;
            }

            //for (int i = 0; i < length; i++)
            //{
            //    array[i] = matrix[i, i];
            //}
            return array;

        }
    }
}

