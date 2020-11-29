using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SparseMatrices
{
    public class Banded
    {
        public (int,int,double[,]) BandedStorage(double[,] matrix)
        {
            double[] row = new double[matrix.GetLength(0)];
            double[] column = new double[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                row[i] = matrix[0, i];
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                column[j] = matrix[j, 0];
            }
            int rowBandwidth = row.ToList().FindLastIndex(x => x > 0);
            int colBandwidth = column.ToList().FindLastIndex(x => x > 0);

            double[,] bandedMatrix = new double[matrix.GetLength(0),rowBandwidth+1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bandedMatrix[0, i] = matrix[i, i];
            }

            for (int i = 0; i < colBandwidth; i++)
            {
                for (int j = 0; j < matrix.GetLength(0)-i-1; j++)
                {
                    bandedMatrix[i+1, j] = matrix[j,j+i+1];
                }
            }

            return (rowBandwidth, colBandwidth, bandedMatrix);
        }

        public double[] BandedMultiplyVector(double[,] matrix, double[] vector)
        {
            Banded result = new Banded();
            ( int rowBandwidth, int colBandwidth, double[,] bandedMatrix) = result.BandedStorage(matrix);
            double[] product = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                
            }


            return product;
        }
    }
}