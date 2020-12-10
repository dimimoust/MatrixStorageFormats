using System;
using System.Collections.Generic;

namespace SparseMatrices
{
    class Program
    {
        static void Main()
        {
            double[,] matrix = { { 1, 2, 3 }, { 0, 2, 0 }, { 0, 5, 3 } };
            double[] vector = { 1, 2, 3 };
            MatrixOperations multiplication = new MatrixOperations(matrix, vector);
            Console.WriteLine($"Multiplication result is = {multiplication.Result}");
            /*double[] matrixp= { 8, 2, 3, 5, 4, 6, };
            double[,] matrix = { { 1, 2, 3 }, { 0, 2, 0 }, { 0, 5,3 } };
            double[,] skymatrix = { { 1, 0, 1, 0, 8,5 }, { 0, 2, 0, 1, 0,0 }, { 1, 0, 3, 1, 0, 1}, { 0, 1, 1, 4, 0,0 }, { 8, 0, 0, 0, 5,1 },{5,0,4,0,1,6} };
            //double[,] skymatrix = {{1,-1,-3,0,0},{-2,5,0,0,0},{0,0,4,6,4},{-4,0,2,7,0},{0,8,0,0,-5}};
            double[,] banmatrix =
            {
                {1, 0, 1, 0, 8, 5, 0, 0, 0, 0, 0},
                {0, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                {1, 0, 3, 1, 0, 1, 0, 0, 0, 0, 0},
                {0, 1, 1, 4, 0, 0, 0, 0, 0, 0, 0},
                {8, 0, 0, 0, 5, 1, 0, 0, 0, 0, 0},
                {5, 0, 4, 0, 1, 6, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };
            double[,] band2 =
            {
                {1, 2, 0, 3, 0, 0, 0, 0},
                {2, 4, 5, 1, 0, 0, 0, 0},
                {0, 5, 6, 1, 0, 1, 0, 0},
                {3, 1, 1, 7, 0, 0, 0, 0},
                {0, 0, 0, 0, 8, 1, 0, 0},
                {0, 0, 1, 0, 1, 9, 0, 0},
                {0, 0, 0, 0, 0, 0, 10, 0},
                {0, 0, 0, 0, 0, 0, 0, 11},
            };
            double[] vector = {2, 4, 5,2};
            CompressedSparseColumns arrayCSR = new CompressedSparseColumns();
            double[] CSC = arrayCSR.CSCvectorMultiplication(vector, matrix);
            PackedStorage matrixrow = new PackedStorage();
           // double[] result = matrixrow.MultiplyWithVector(matrixp, vector);
            double[,] matrixD = { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 2 } };
            double[,] diagonal = { { 1, 0, 0,4 }, { 0, 5, 3,5 }, { 0, 3, 6,0 } ,{4,5,0,8}};
            double[,] csR = {{9, 0, 3, 0}, {0, 8, 0, 0}, {0, 2, 6, 0}, {1, 0, 0, 5}};
            Banded pinakas = new Banded();

            var (res,res1, _, _) = pinakas.BandedStorage(band2);
            PackedStorage array = new PackedStorage();
           ( double[],int[],int[]) packedArrayColumn = array.Row_Major_Layout(diagonal);
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
            double[,] skyline = arrayS.SkylineStorage(skymatrix);

            var matrixFull = new Matrix(diagonal);
            //matrixFull[0, 0]*/
        }
    }
}
