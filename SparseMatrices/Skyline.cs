using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    public class Skyline
    {
        private readonly double[,] Matrix;
        private double[] values;
        private int[] diagOffSets;

        public double[] Values
        {
            get => values;
            set => values = value;
        }
        public int[] DiagOffSets
        {
            get => diagOffSets;
            set => diagOffSets = value;
        }

        public Skyline(double[,] matrix)
        {
            _listValues = new List<double>();
            this.Matrix = matrix;
            var (_, skyValues ,skyDiagOffsets) = SkylineStorage(matrix);
            this.Values = skyValues;
            this.DiagOffSets = skyDiagOffsets;
        }

        public double this[int i, int j]
        {
            get => Matrix[i, j];
            set => Matrix[i, j] = value;
        }

        public (double[,] ,double[] , int[] ) SkylineStorage(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            double[,] matrixSkyLine = new double[rows, columns];
            int[] activeColumn = new int[columns];
            int[] height = new int[columns];

            for (int indexColumn = 0; indexColumn < columns; indexColumn++)
            {
                int count = 0;
                for (int indexRow = 0; indexRow < indexColumn; indexRow++)
                {
                    if (matrix[indexRow, indexColumn] == 0)
                    {
                        count = count + 1;
                    }
                    else
                    {
                        break;
                    }
                }

                height[indexColumn] = count;
            }

            int sum = 0;
            for (int i = 0; i < height.Length; i++)
            {
                sum += height[i];
            }

            int totalvalues = 0;
            for (int indexRow = 0; indexRow < rows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn <= indexRow; indexColumn++)
                {
                    totalvalues++;
                }
            }

            if (matrix[0, 0] != 0)
            {
                _listValues.Add(matrix[0, 0]);
            }
            for (int indexRow = 1; indexRow < rows; indexRow++)
            {
                for (int indexColumn = indexRow; indexColumn >= height[indexColumn] && indexColumn > 0; indexColumn--)
                {
                    _listValues.Add(matrix[indexRow, indexColumn]);
                }
                if (matrix[0, indexRow] != 0)
                {
                    _listValues.Add(matrix[0, indexRow]);
                }
            }

            double[] values = _listValues.ToArray();
            int[] diagOffsets = new int[columns + 1];
            diagOffsets[columns] = totalvalues - sum;
            for (int indexRow = 1; indexRow < rows; indexRow++)
            {
                diagOffsets[indexRow] = diagOffsets[indexRow - 1] + (indexRow - height[indexRow - 1]);
            }

            for (int j = 0; j < columns; j++)
            {
                activeColumn[j] = diagOffsets[j + 1] - diagOffsets[j] - 1;
            }

            /*int m = 0;
            var matrixDOK = new Dictionary<int, Dictionary<int, double>>();
            for (int i = 0; i < m; i++)
            {
                matrixDOK[i] = new Dictionary<int, double>();
            }*/

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j >= i)
                    {
                        if (j - i <= activeColumn[j])
                        {
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

            return (matrixSkyLine, values , diagOffsets);
        }

        List<double> _listValues;
    }
}


