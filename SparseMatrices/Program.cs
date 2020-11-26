using System;
using System.Collections.Generic;

namespace SparseMatrices
{
    class Program
    {
        static void Main()
        {
            double[,] matrix = { { 1, 2, 3 }, { 0, 0, 0 }, { 0, 5, 0 } };
            double[,] matrixD = { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 2 } };
            double[,] diagonal = { { 1, 0, 0,4 }, { 0, 5, 3,5 }, { 0, 3, 6,0 } ,{4,5,0,8}};
            double[,] csR = {{9, 0, 3, 0}, {0, 8, 0, 0}, {0, 2, 6, 0}, {1, 0, 0, 5}};
            PackedStorage array = new PackedStorage();
            double[] packedArrayColumn = array.Column_Major_Layout(matrix);
            double[] packedArrayRow = array.Row_Major_Layout(matrix);
            Diagonal arrayD = new Diagonal();
            double[] diagonalStorage = arrayD.DiagonalMatrices(matrixD);
            CoordinateList arraycl = new CoordinateList();
            //(double[], double[], double[]) NonZeroEntries = arraycl.CoordinateListStorage(matrix);
            var (values, _, columns) = arraycl.CoordinateListStorage(matrix);
            CompressedSparseColumns arrayCsr = new CompressedSparseColumns();
            (double[], double[] , double[]) csr = arrayCsr.CSCstorage(csR);
            DictionaryOfKeys arrayDk = new DictionaryOfKeys();
            Dictionary<int, Dictionary<int, double>> dok = arrayDk.DOK(matrix);
            Skyline arrayS = new Skyline();
            double[] skyline = arrayS.SkylineStorage(diagonal);
            
        }
    }
}
