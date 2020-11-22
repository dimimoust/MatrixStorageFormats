using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    public class CoordinateList : NonZerosEntries
    {       
        public (double[] values, double[] rows, double[] columns) CoordinateListStorage(double[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            int nonzerosentries = FindNonZeroEntries(matrix);
            double[] values = new double[nonzerosentries];
            double[] rows = new double[nonzerosentries];
            double[] columns = new double[nonzerosentries];
            int k = 0;
            for (int index_row = 0; index_row < row; index_row++)
            {
                for (int index_column = 0; index_column < column; index_column++)
                {
                    if (matrix[index_row, index_column] != 0)
                    {
                        values[k] = (matrix[index_row, index_column]);
                        rows[k] = index_row;
                        columns[k] = index_column;
                        k++;
                    }
                }
            }
            
            return (values,rows,columns);
        }
    }
}
