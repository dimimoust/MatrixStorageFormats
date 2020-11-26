using System.Collections.Generic;

namespace SparseMatrices
{
    public class CoordinateList
    {
        public CoordinateList()
        {
            _listvalues = new List<double>();
            _listrows = new List<double>();
            _listcolumns = new List<double>();
        }

        public (double[] values, double[] rows, double[] columns) CoordinateListStorage(double[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            for (int indexRow = 0; indexRow < row; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < column; indexColumn++)
                {
                    if (matrix[indexRow, indexColumn] != 0)
                    {
                        _listvalues.Add(matrix[indexRow, indexColumn]);
                        _listrows.Add(indexRow);
                        _listcolumns.Add(indexColumn);
                    }
                }
            }

            double[] values = _listvalues.ToArray();
            double[] rows = _listrows.ToArray();
            double[] columns = _listcolumns.ToArray();
            return (values,rows,columns);
        }

        List<double> _listvalues;
        List<double> _listrows;
        List<double> _listcolumns;
    }
}
