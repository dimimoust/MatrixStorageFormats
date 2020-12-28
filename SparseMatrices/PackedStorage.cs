using System.Collections.Generic;

namespace SparseMatrices
{
    public class PackedStorage
    {
        public PackedStorage()
        {
            _listrows = new List<int>();
            _listcolumns = new List<int>();
        }
        //Column Major Layout 
        public (double[],int[],int[]) Column_Major_Layout(double[,] matrix)
        {
            int length = matrix.GetLength(1);
            int entries = length * (length + 1) / 2;
            double[] array = new double[entries];

            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i <= j; i++)
                {
                    array[i + j * (j + 1) / 2] = matrix[i, j];
                    _listrows.Add(i);
                    _listcolumns.Add(j);
                }
            }

            int[] rows = _listrows.ToArray();
            int[] columns = _listcolumns.ToArray();

            return (array, rows, columns);
            
        }

        //Row Major Layout 
        public (double[], int[], int[]) Row_Major_Layout(double[,] matrix)
        {
            int length = matrix.GetLength(1);
            int entries = length * (length + 1) / 2;
            double[] array = new double[entries];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i <= j)
                    {
                        array[j + (2 * length - i - 1) * i / 2] = matrix[i, j];



                        _listrows.Add(i);
                        _listcolumns.Add(j);
                    }
                }
            }
            int[] rows = _listrows.ToArray();
            int[] columns = _listcolumns.ToArray();
            return (array, rows, columns);
        }

        //public double[] MultiplyWithVector(double[,] matrix, double[] vector)
        //{
        //    PackedStorage a = new PackedStorage();
        //   var(array,rows,columns)  = a.Row_Major_Layout(matrix);
        //    double[] y = new double[vector.Length];
        //    for (int i = 0; i < vector.Length; i++)
        //    {
        //        y[i] = 0;
        //        for (int j = 0; j < vector.Length;  j++)
        //        {
        //            if (i <= j)
        //            {
        //                y[i] = y[i] + array[columns[j]] * vector[i];
        //            }
        //            else
        //            {
        //                y[i] = y[i] + array[columns[i]]* vector[i];
        //            }
        //        }
        //    }
        //    return y;
        //}

        List<double> _listvalues;
        List<int> _listrows;
        List<int> _listcolumns;
    }
}
