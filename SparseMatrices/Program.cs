using System;
using System.Collections.Generic;

namespace SparseMatrices
{
    class Program
    {
        static void Main()
        {
            double[,] matrix = { { 1, 2, 3 }, { 0, 5, 3 }, { 0, 0, 1 } };
            double[,] matrixD = { { 1, 0, 0 }, { 0, 5, 0 }, { 0, 0, 2 } };
            double[,] diagonal = { { 1, 0, 3 }, { 0, 5, 0 }, { 3, 0, 6 } };
            PackedStorage array = new PackedStorage();
            double[] PackedArrayColumn = array.Column_Major_Layout(matrix);
            double[] PackedArrayRow = array.Row_Major_Layout(matrix);
            Diagonal arrayD = new Diagonal();
            double[] DiagonalStorage = arrayD.DiagonalMatrices(matrixD);
            CoordinateList arraycl = new CoordinateList();
            //(double[], double[], double[]) NonZeroEntries = arraycl.CoordinateListStorage(matrix);
            var (values, _, columns) = arraycl.CoordinateListStorage(matrix);
            CompressedSparseRows arrayCSR = new CompressedSparseRows();
            (double[], double[]) CSR = arrayCSR.CSRstorage(matrix);
            DictionaryOfKeys arrayDK = new DictionaryOfKeys();
            Dictionary<int, Dictionary<int, double>> dok = arrayDK.DOK(matrix);
            Skyline arrayS = new Skyline();
            double[] skyline = arrayS.SkylineStorage(diagonal);
            
        }
    }
}
