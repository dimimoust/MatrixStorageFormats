using System.Collections.Generic;

namespace SparseMatrices
{

    public class CompressedSparseRows
    {
        public CompressedSparseRows()
        {
            _listValues = new List<double>();
            _listColIndices = new List<int>();
        }

        public (double[] values, int[] colindices, int[] rowoffsets) CSRstorage(double[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            int[] rowoffsets = new int[row + 1];
            for (int indexRow = 0; indexRow < row; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < column; indexColumn++)
                {
                    if (matrix[indexRow, indexColumn] != 0)
                    {
                        _listValues.Add(matrix[indexRow, indexColumn]);
                        _listColIndices.Add(indexColumn);
                    }

                    if (matrix[0, indexColumn] != 0)
                    {
                        rowoffsets[0] = 0;
                    }
                }

                rowoffsets[indexRow + 1] = _listValues.Count;
            }

            rowoffsets[row] = _listValues.Count;

            double[] values = _listValues.ToArray();
            int[] colIndices = _listColIndices.ToArray();


            return (values, colIndices, rowoffsets);

        }

        List<double> _listValues;
        List<int> _listColIndices;


        public double[] CSRvectorMultiplication(double[] vector, double[,] matrix)
        {
            CompressedSparseRows csr = new CompressedSparseRows();
            (double[] values, int[] colIndices, int[] rowoffsets) = csr.CSRstorage(matrix);

            double[] product = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0) ; i++)
            {
                product[i] = 0;
                for (int k = rowoffsets[i]; k < rowoffsets[i + 1] ; k++)
                {
                    product[i] = product[i] + values[k] * vector[colIndices[k]];
                }
            }
            return product;
        }

    }

}
