using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    public class NonZerosEntriesSym
    {
        public NonZerosEntriesSym()   //constructor
        {
            _list = new List<double>();
        }
        public int FindNonZeroEntries(double[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            //List<double> list = new List<double>();     2nd way for initialization list
            int nnz = 0;
            double[] inof = new double[row+1];
            for (int indexRow = 0; indexRow < row; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < column; indexColumn++)
                {
                    if (indexRow <= indexColumn )
                    {
                        if (matrix[indexRow, indexColumn] != 0)
                        {
                            _list.Add(matrix[indexRow, indexColumn]);
                            nnz++;
                        }
                    }                    
                }
            }
            int nonzerosentries = _list.Count;
            return nonzerosentries;
        }
        List<double> _list;
    }
}
