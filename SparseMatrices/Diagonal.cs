using SparseMatrices.Interfaces;

namespace SparseMatrices
{
    public class Diagonal:IMatrix
    {
        private double[] array;
        public double[] Array
        {
            get => array;
            set => array = value;
        }
        public Diagonal(double[,] matrix)
        {
            double[] array = DiagonalMatrices(matrix);
            this.Array = array;
        }
        public double[] DiagonalMatrices(double[,] matrix)
        {
            int length = matrix.GetLength(0);
            double[] array = new double[length];

            //int i = 0;
            //int j = 0;
            //while (i == j && i < length)
            //{
            //    array[i] = matrix[i, j];
            //    i++;
            //    j++;
            //}

            for (int i = 0; i < length; i++)
            {
                array[i] = matrix[i, i];
            }
            return array;
        }
        
        public double[] Multiplication(double[] vector)
        {
            //Diagonal diagonal = new Diagonal();
            //double[] array = diagonal.DiagonalMatrices(matrix);
            double[] product = new double[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                product[i] = array[i] * vector[i];
            }

            return product;
        }
    }
}

