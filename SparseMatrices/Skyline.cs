using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    public class Skyline : NonZerosEntriesSym
    {
        public double[] SkylineStorage(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int nonzerosentries = FindNonZeroEntries(matrix);
            double[] values = new double[nonzerosentries];
            double[] col_indices = new double[nonzerosentries];
            double[] diag_offsets = new double[columns + 1];
            double[] row_indices = new double[nonzerosentries];
            double[] array = new double[rows * columns];
            double[] active_column = new double[columns];
            int k = 0; 
            int n = 0;
            for (int index_row = 0; index_row < rows; index_row++)
            {
                for (int index_column = 0; index_column < columns; index_column++)
                {
                    if (index_row <= index_column)
                    {
                        if (matrix[index_row, index_column] != 0)
                        {
                            values[k] = (matrix[index_row, index_column]);
                            k++;
                            if (index_row == index_column)
                            {
                                diag_offsets[n] = n;
                                n++;
                            }
                            diag_offsets[columns] = nonzerosentries;
                        }                       
                    }
                }                
            }
            for (int j = 0; j < columns; j++)
            {
                active_column[j] = diag_offsets[j + 1] - diag_offsets[j] - 1;
            }

            for (int index_row = 0; index_row < rows; index_row++)
            {
                for (int index_column = 0; index_column < columns; index_column++)
                {
                   //matrix[index_column,index_row] = values[diag_offsets[index_column] + index_column - index_row];
                }
            }
            return values;
        }
    }
}


