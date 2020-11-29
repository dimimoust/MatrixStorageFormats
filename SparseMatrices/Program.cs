using System;
using System.Collections.Generic;

namespace SparseMatrices
{
    class Program
    {
        static void Main()
        {
            double[] matrixp= { 8, 2, 3, 5, 4, 6, };
            double[,] matrix = { { 1, 2, 3 }, { 0, 2, 0 }, { 0, 5,3 } };
            double[] vector = {2, 4, 5,2};
            CompressedSparseColumns arrayCSR = new CompressedSparseColumns();
            double[] CSC = arrayCSR.CSCvectorMultiplication(vector, matrix);
            PackedStorage matrixrow = new PackedStorage();
           // double[] result = matrixrow.MultiplyWithVector(matrixp, vector);
            double[,] matrixD = { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 2 } };
            double[,] diagonal = { { 1, 0, 0,4 }, { 0, 5, 3,5 }, { 0, 3, 6,0 } ,{4,5,0,8}};
            double[,] csR = {{9, 0, 3, 0}, {0, 8, 0, 0}, {0, 2, 6, 0}, {1, 0, 0, 5}};
            Banded pinakas = new Banded();
            var aarray = pinakas.BandedMultiplyVector(diagonal,vector);
            PackedStorage array = new PackedStorage();
            double[] packedArrayColumn = array.Column_Major_Layout(matrix);
            double[] packedArrayRow = array.MultiplyWithVector(diagonal,vector);
            Diagonal arrayD = new Diagonal();
            double[] diagonalStorage = arrayD.DiagonalVectorMultiplication(vector, matrixD);
            CoordinateList arraycl = new CoordinateList();
            double[] result2 = arraycl.CoordListvectorMultiplication(vector,matrix);
            var (values, _, columns) = arraycl.CoordinateListStorage(matrix);
            CompressedSparseColumns arrayCsr = new CompressedSparseColumns();
            (double[], int[] , int[]) csr = arrayCsr.CSCstorage(csR);
            DictionaryOfKeys arrayDk = new DictionaryOfKeys();
            Dictionary<int, Dictionary<int, double>> dok = arrayDk.DOK(matrix);
            Skyline arrayS = new Skyline();
            double[] skyline = arrayS.SkylineStorage(diagonal);

            
        }
    }
}
