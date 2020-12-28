using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using SparseMatrices.Interfaces;

namespace SparseMatrices
{
    public class DenseMatrix:IMatrix
    {
        private readonly double[,] _values;

        public DenseMatrix(double[,] values)
        {
            _values = values;
        }

        public double this[int i, int j]
        {
            get => _values[i, j];
            set => _values[i, j] = value;
        }

        public double GetValue(int i, int j) => _values[i, j];
        public void SetValue(int i, int j, double value) => _values[i, j]=value;

        public double[] Multiplication(double[] vector)
        {
            var result = new double[_values.GetLength(0)];
            var rows = _values.GetLength(0);
            var columns= _values.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                var sum = 0.0;
                for (int j = 0; j < columns; j++)
                {
                    sum += _values[i, j] * vector[j];
                }

                result[i] = sum;
            }

            return result;
        }
    }
}
