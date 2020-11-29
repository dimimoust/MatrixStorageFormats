namespace SparseMatrices
{
    public class PackedStorage
    {
        //Column Major Layout 
        public double[] Column_Major_Layout(double[,] matrix)
        {
            int length = matrix.GetLength(1);
            int entries = length * (length + 1) / 2;
            double[] array = new double[entries];

            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i <= j; i++)
                {
                    array[i + j * (j + 1) / 2] = matrix[i, j];
                }
            }
            return array;
        }

        //Row Major Layout 
        public double[] Row_Major_Layout(double[,] matrix)
        {
            int length = matrix.GetLength(1);
            int entries = length * (length + 1) / 2;
            double[] array = new double[entries];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j<length; j++)
                {
                    if (i<=j)
                    {
                        array[j + (2 * length - i - 1) * i / 2] = matrix[i, j];
                    }                                        
                }
            }
            return array;
        }

        public double[] MultiplyWithVector(double[,] matrix, double[] vector)
        {
            PackedStorage a = new PackedStorage();
            double[] array = a.Row_Major_Layout(matrix);
            double[] y = new double[vector.Length];
            int n = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                y[i] = 0;
                for (int k = i; k < vector.Length;  k++)
                {
                    y[i] = y[i] + array[n]*vector[k];
                    n++;
                }
            }
            return y;
        }
       /* public double[] MultiplyWithVector(double[] packedStorageCol, double[] vector)
        {
            return new double[5];
        }

        public double this[int indexRow, int indexColumn]
        {
            get { return 5; }
        }*/
    }
}
