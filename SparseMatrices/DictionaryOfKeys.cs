﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    public class DictionaryOfKeys
    {
        public Dictionary<int, Dictionary<int, double>> DOK(double[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            var matrixDOK = new Dictionary<int, Dictionary<int, double>>();
            /* for (int i = 0; i < row; i++)
             {
                 matrixDok[i] = new Dictionary<int, double>();
             }*/

            for (int indexRow = 0; indexRow < row; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < column; indexColumn++)
                {
                    if (matrix[indexRow, indexColumn] != 0)
                    {
                        if(!matrixDOK.ContainsKey(indexRow))
                           matrixDOK[indexRow] = new Dictionary<int, double>();
                        matrixDOK[indexRow][indexColumn] = matrix[indexRow, indexColumn];
                    }       
                }
            }
            return matrixDOK;
        }
    }
}
