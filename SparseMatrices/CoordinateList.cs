using System.Collections.Generic;

namespace SparseMatrices
{
    public class CoordinateList
    {
        public CoordinateList()
        {
            _listvalues = new List<double>();
            _listrows = new List<int>();
            _listcolumns = new List<int>();
        }

        public (double[] values, int[] rows, int[] columns) CoordinateListStorage(double[,] matrix)
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
            int[] rows = _listrows.ToArray();
            int[] columns = _listcolumns.ToArray();
            return (values,rows,columns);
        }

        List<double> _listvalues;
        List<int> _listrows;
        List<int> _listcolumns;

        public double[] CoordListvectorMultiplication(double[] vector, double[,] matrix)
        {
            CoordinateList coordinatelist = new CoordinateList();
            (double[] values, int[] rows, int[] columns) = coordinatelist.CoordinateListStorage(matrix);

            double[] product = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                product[i] = 0;
            }
            for (int k = 0 ; k < values.Length; k++)
            {
                product[rows[k]] = product[rows[k]] + values[k]*vector[columns[k]];
            }
            
            return product;
        }
    }
}
