using System.Collections.Generic;

namespace SparseMatrices
{

    public class CompressedSparseRows
    {
        public CompressedSparseRows()
        {
            _listValues = new List<double>();
            _listColIndices = new List<double>();
        }

        public (double[] values, double[] colindices, double[] rowoffsets) CSRstorage(double[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            double[] rowoffsets = new double[row + 1];
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
            double[] colIndices = _listColIndices.ToArray();

            return (values, colIndices, rowoffsets);
        }

        List<double> _listValues;
        List<double> _listColIndices;
    }

}
