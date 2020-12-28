using System.Collections.Generic;
using SparseMatrices.Interfaces;

namespace SparseMatrices
{

    public class CompressedSparseColumns:IMatrix
    {
        private double[] values;
        private int[] rowIndices;
        private int[] colOffsets;

        public double[] Values
        {
            get => values;
            set => values = value;
        }
        public int[] RowIndices
        {
            get => rowIndices;
            set => rowIndices = value;
        }

        public int[] ColOffsets
        {
            get => colOffsets;
            set => colOffsets = value;
        }
        public CompressedSparseColumns(double[,] matrix)
        {
            _listvalues = new List<double>();
            _listRowIndices = new List<int>();

            var (values, rowIndices, colOffsets) = CSCstorage(matrix);

            this.Values = values;
            this.RowIndices = rowIndices;
            this.ColOffsets = colOffsets;

        }

        public (double[] values, int[] rowindices, int[] coloffsets) CSCstorage(double[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            int[] coloffsets = new int[column + 1];
            for (int indexColumn = 0; indexColumn < column; indexColumn++)
            {
                for (int indexRow = 0; indexRow < row; indexRow++)
            {
             
                    if (matrix[indexRow, indexColumn] != 0)
                    {
                        _listvalues.Add(matrix[indexRow, indexColumn]);
                        _listRowIndices.Add(indexRow);
                    }

                    if (matrix[indexRow, 0] != 0)
                    {
                        coloffsets[0] = 0;
                    }
                }
                coloffsets[indexColumn + 1] = _listvalues.Count;
            }
            coloffsets[column] = _listvalues.Count;
            
            double[] values = _listvalues.ToArray();
            int[] rowIndices = _listRowIndices.ToArray();

            return (values, rowIndices, coloffsets);
        }

        List<double> _listvalues;
        List<int> _listRowIndices;

        public double[] Multiplication(double[] vector)
        {
            //CompressedSparseColumns csr = new CompressedSparseColumns();
            //(double[] values, int[] rowIndices, int[] coloffsets) = csr.CSCstorage(matrix);

            double[] product = new double[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                product[i] = 0;
            }

            for (int i = 0; i < vector.Length; i++)
            {
                for (int k = colOffsets[i]; k < colOffsets[i + 1]; k++)
                {
                    product[rowIndices[k]] = product[rowIndices[k]] + values[k] * vector[i];
                }
            }

            return product;

        }
    }

}
