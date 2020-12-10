using System;
using System.Collections.Generic;
using System.Text;

namespace SparseMatrices
{
    class MatrixOperations
    {
        private readonly double[,] Values;
        private double[] result;

        public double this[int i, int j]
        {
            get => Values[i, j];
            set => Values[i, j] = value;
        }

        public double[] Result
        {
            get => result;
            set => result = value;
        }


        public MatrixOperations(double[,] values, double[] vector)
        {
            this.Values = values;
            this.Result = Multiply(vector);
        }

        public double[] Multiply(double[] vector)
        {
            var resultOfMultiplication = new double[Values.GetLength(0)];
            var rows = Values.GetLength(0);
            var columns = Values.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                var sum = 0.0;
                for (int j = 0; j < columns; j++)
                {
                    sum += Values[i, j] * vector[j];
                }

                resultOfMultiplication[i] = sum;
            }

            return resultOfMultiplication;
        }
    }
}
