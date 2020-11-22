using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    public class NonZerosEntries
    {
        public NonZerosEntries()   //constructor
        {
            list = new List<double>();
        }
        public int FindNonZeroEntries(double[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            //List<double> list = new List<double>();     2nd way for initialization list
            int nnz = 0;
            double[] inof = new double[row+1];
            for (int index_row = 0; index_row < row; index_row++)
            {
                for (int index_column = 0; index_column < column; index_column++)
                {
                    if (matrix[index_row, index_column] != 0)
                    {
                        list.Add(matrix[index_row, index_column]);
                        nnz++;
                    }
                }
                //inof = nnz;
            }
            int nonzerosentries = list.Count;

            return nonzerosentries;

        }
        List<double> list;
    }
}
