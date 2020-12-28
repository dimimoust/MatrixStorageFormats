using System.Collections.Generic;

namespace SparseMatrices
{
    class Program
    {
        static void Main()
        {
            // 1. Full/Dense DenseMatrix Multiplication
            double[,] matrix = {{1, 2, 3, 4, 5}, {6, 7, 8, 9, 10}, {3, 4, 6, 7, 8}, {8, 4, 9, 6, 7}, {2, 6, 9, 3, 45}};
            double[] vector = {1, 2, 3, 4, 5};
            DenseMatrix denseMatrix = new DenseMatrix(matrix);
            denseMatrix.Multiplication(vector);

            // 2. Diagonal DenseMatrix
            double[,] matrix2 = { { 1, 0, 0, 0 }, { 0, 5, 0, 0 }, { 0, 0, 6, 0 }, { 0, 0, 0, 8 } };
            double[] vector2 = { 2, 4, 5, 2 };
            Diagonal diagonal = new Diagonal(matrix2);
            double[] result1 = diagonal.Multiplication(vector2);

            // 3. Coordinate List
            double[,] matrix3 = { { 9, 0, 3, 0 }, { 0, 8, 0, 0 }, { 0, 2, 6, 0 }, { 1, 0, 0, 5 } };
            CoordinateList coordList = new CoordinateList(matrix3);
            double[] result3 = coordList.Multiplication(vector2);

            // 4. CompressedSparseColumns
            CompressedSparseColumns compressedSparseColumns = new CompressedSparseColumns(matrix3);
            double[] result4 = compressedSparseColumns.Multiplication(vector2);

            // 5. CompressedSparseRows
            CompressedSparseColumns compressedSparseRows = new CompressedSparseColumns(matrix3);
            double[] result5 = compressedSparseRows.Multiplication(vector2);

            // 6. Dictionary of Keys
            DictionaryOfKeys dictionaryOfKeys = new DictionaryOfKeys(matrix3);

            // 7. Banded
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

            // 8. PackedStorage
            double[,] matrix8 = { { 9, 0, 3, 0 }, { 0, 8, 6, 5 }, { 3, 6, 7, 4 }, { 0, 5, 4, 8 } };
            PackedStorage array = new PackedStorage();
            (double[], int[], int[]) packedArrayColumn = array.Row_Major_Layout(matrix8);
            (double[], int[], int[]) packedArrayRow = array.Column_Major_Layout(matrix8);

            // 9. SkyLine Storege
            double[,] skymatrix = { { 1, 0, 1, 0, 8, 5 }, 
                                    { 0, 2, 0, 1, 0, 0 }, 
                                    { 1, 0, 3, 1, 0, 1 },
                                    { 0, 1, 1, 4, 0, 0 }, 
                                    { 8, 0, 0, 0, 5, 1 }, 
                                    { 5, 0, 4, 0, 1, 6 } };
            Skyline skyline = new Skyline(skymatrix);

            //var matrixFull = new DenseMatrix(diagonal);
            //matrixFull[0, 0]
        }
    }
}
