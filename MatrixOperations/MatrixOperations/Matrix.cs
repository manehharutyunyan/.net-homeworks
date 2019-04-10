using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations
{
    class Matrix
    {
        public int[,] Array { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public Matrix(int[,] array, int row, int column)
        {
            this.Array = array;
            this.Row = row;
            this.Column = column;
        }

        public static void Print(Matrix matrix)
        {
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Column; j++)
                {
                    Console.Write(matrix.Array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void GenerateMatrix(Matrix matrix)
        {
            var rnd = new Random();
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Column; j++)
                {
                    matrix.Array[i, j] = rnd.Next(100);
                }
            }
        }

        public static Matrix Add(Matrix m1, Matrix m2)
        {
            if (m1.Row != m2.Row || m1.Column != m2.Column)
            {
                Console.WriteLine("Matrices must have the same number of rows and columns.");
                return null;
            }
                Console.WriteLine("\nThe sum of the two matrices is :");
                int row = m1.Row;
                int column = m1.Column;
                int[,] result = new int[row, column];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        result[i, j] = m1.Array[i, j] + m2.Array[i, j];
                    }
                }
                return  new Matrix(result, row, column);
        }

        public static Matrix Multiply(Matrix m1, Matrix m2)
        {
            if (m1.Column != m2.Row)
            {
                Console.WriteLine("Number of columns in the first matrix must be equal to the number of rows in the second matrix.");
                return null;
            }
                //Console.WriteLine("\nThe product of the two matrices is :");
                int row = m1.Row;
                int column = m2.Column;
                int[,] result = new int[row, column];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        result[i, j] = 0;
                        for (int k = 0; k < m1.Column; k++)
                        {
                            result[i, j] += m1.Array[i, k] * m2.Array[k, j];
                        }
                    }
                }
            return new Matrix(result, row, column);
        }

        public static Matrix ScalarProduct(Matrix m, int s)
        {
                //Console.WriteLine("\nScalar multiplication of a matrix:");
                int row = m.Row;
                int column = m.Column;
                int[,] result = new int[row, column];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        result[i, j] = m.Array[i, j] * s;
                    }
                }
                return new Matrix(result, row, column);
        }

        public static Matrix TransposeMatrix(Matrix m)
        {
           // Console.WriteLine("\nTranspose matrix:");
            int row = m.Column;
            int column = m.Row;
            int[,] result = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    result[i, j] = m.Array[j, i];
                }
            }
           return new Matrix(result, row, column);
        }

        public static bool IsIdentity(Matrix m)
        {
            int row = m.Row;
            int column = m.Column;
            if (row != column)
                return false;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if(i == j)
                    {
                        if (m.Array[i, j] != 1)
                            return false;
                    }
                    else
                    {
                        if (m.Array[i, j] != 0)
                            return false;
                    }
                }
            
}
            return true;
        }

        public static bool IsOrthogonal(Matrix m)
        {
            Matrix product = Multiply(m, TransposeMatrix(m));
            if (IsIdentity(product))
                return true;
            return false;
        }

        public static int MaxElement(Matrix matrix)
        {
            int max = matrix.Array[0, 0];
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Column; j++)
                {
                    if (matrix.Array[i, j] > max)
                        max = matrix.Array[i, j];
                }
            }
            return max;
        }

        public static int MinElement(Matrix matrix)
        {
            int min = matrix.Array[0, 0];
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Column; j++)
                {
                    if (matrix.Array[i, j] < min)
                        min = matrix.Array[i, j];
                }
            }
            return min;
        }
    }
}
