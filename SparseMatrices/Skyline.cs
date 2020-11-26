using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    public class Skyline
    {
        public Skyline()
        {
            _listValues = new List<double>();
            _listDiagOffsets = new List<int>();
        }
        public double[] SkylineStorage(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            double[,] matrixSkyLine = new double[rows,columns];
            double[] activeColumn = new double[columns];
            int n = 0;
            for (int indexRow = 0; indexRow < rows; indexRow++)
            {
                for (int indexColumn = indexRow; indexColumn >= 0; indexColumn--)
                {
                    if (matrix[indexRow, indexColumn] != 0)
                    {
                        _listValues.Add(matrix[indexRow, indexColumn]);
                        if (indexRow == indexColumn)
                        {
                            _listDiagOffsets.Add(n);
                        }
                        n++;
                    }
                }
            }

            _listDiagOffsets.Add(_listValues.Count);
            int[] diagOffsets = _listDiagOffsets.ToArray();
            double[] values = _listValues.ToArray();

            for (int j = 0; j < columns; j++)
            {
                activeColumn[j] = diagOffsets[j + 1] - diagOffsets[j] - 1;
            }

            int m = 0;
            var matrixDOK = new Dictionary<int, Dictionary<int, double>>();
            for (int i = 0; i < m; i++)
            {
                matrixDOK[i] = new Dictionary<int, double>();
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j >= i)
                    {
                        if (j - i <= activeColumn[j])
                        {
                            var a = diagOffsets[j] + j - i;
                            matrixSkyLine[i, j] = values[diagOffsets[j] + j - i];
                        }
                        else
                        {
                            matrixSkyLine[i, j] = 0;
                        }
                    }
                    matrixSkyLine[j, i] = matrixSkyLine[i, j];
                }
            }
            return values;
        }

        List<double> _listValues;
        List<int> _listDiagOffsets;
    }
}


