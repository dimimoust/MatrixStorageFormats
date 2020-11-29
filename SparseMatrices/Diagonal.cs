namespace SparseMatrices
{
    public class Diagonal
    {
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

        public double[] DiagonalVectorMultiplication(double[] vector , double[,] matrix)
        {
            Diagonal diagonal = new Diagonal();
            double[] array = diagonal.DiagonalMatrices(matrix);
            double[] product = new double[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                product[i] = array[i] * vector[i];
            }

            return product;
        }
    }
}

