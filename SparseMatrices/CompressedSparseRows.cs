using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    public class CompressedSparseRows : NonZerosEntries
    {
        public (double[] values, double[] col_indices) CSRstorage(double[,] matrix)
        {
            //, double[] row_offsets
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            int nonzerosentries = FindNonZeroEntries(matrix);
            double[] values = new double[nonzerosentries];
            double[] col_indices = new double[nonzerosentries];
            double[] row_offsets = new double[row + 1];
            double[] row_indices = new double[nonzerosentries];
            double[] array = new double[row*column];
            int k = 0;
            int m = 0;
            for (int index_row = 0; index_row < row; index_row++)
            {
                for (int index_column = 0; index_column < column; index_column++)
                {
                    if (matrix[index_row, index_column] != 0)
                    {
                        values[k] = (matrix[index_row, index_column]);
                        col_indices[k] = index_column;
                        row_indices[k] = index_row;

                        k++;
                    }
                }
            }
           /* for (int n = 0; n < row_indices.Length; n++)
            {
                if (row_indices[n + 1] != row_indices[n])
                {
                    row_offsets[m] = n;
                    m++;
                }
                
            }*/
            

            return (values, col_indices);
        }
    }
}
