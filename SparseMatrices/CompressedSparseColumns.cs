using System.Collections.Generic;

namespace SparseMatrices
{

    public class CompressedSparseColumns
    {
        public CompressedSparseColumns()
        {
            _listvalues = new List<double>();
            _listRowIndices = new List<double>();
        }

        public (double[] values, double[] colindices, double[] rowoffsets) CSCstorage(double[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            double[] coloffsets = new double[column + 1];
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
            double[] rowIndices = _listRowIndices.ToArray();

            return (values, rowIndices, coloffsets);
        }

        List<double> _listvalues;
        List<double> _listRowIndices;
    }

}
