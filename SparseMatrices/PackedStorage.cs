using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    public class PackedStorage
    {
        //Column Major Layout 
        public double[] Column_Major_Layout(double[,] matrix)
        {
            int length = matrix.GetLength(1);
            int entries = length * (length + 1) / 2;
            double[] array = new double[entries];

            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i <= j; i++)
                {
                    array[i + j * (j + 1) / 2] = matrix[i, j];
                }
            }
            return array;
        }

        //Row Major Layout 
        public double[] Row_Major_Layout(double[,] matrix)
        {
            int length = matrix.GetLength(1);
            int entries = length * (length + 1) / 2;
            double[] array = new double[entries];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j<length; j++)
                {
                    if (i<=j)
                    {
                        array[j + (2 * length - i - 1) * i / 2] = matrix[i, j];
                    }                                        
                }
            }
            return array;
        }


        public double[] MultiplyWithVector(double[] packedStorageCol, double[] vector)
        {
            return new double[5];
        }

        public double this[int indexRow, int indexColumn]
        {
            get { return 5; }
        }
    }
}
