using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    public class DictionaryOfKeys:NonZerosEntries
    {
        public Dictionary<int, Dictionary<int, double>> DOK(double[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            int nonzerosentries = FindNonZeroEntries(matrix);
            var matrixDOK = new Dictionary<int, Dictionary<int, double>>();
            int j = 0;
            int k = 0;
            for (int i = 0; i < row; i++)
            {
                matrixDOK[i] = new Dictionary<int, double>();
            }

            for (int index_row = 0; index_row < row; index_row++)
            {
                for (int index_column = 0; index_column < column; index_column++)
                {
                    if (matrix[index_row, index_column] != 0)
                    {
                        //if(!matrixDOK.ContainsKey(index_row))
                        //    matrixDOK[index_row] = new Dictionary<int, double>();
                        matrixDOK[index_row][index_column] = matrix[index_row, index_column];
                       

                    }       
                }
            }
            return matrixDOK;
        }
    }
}
