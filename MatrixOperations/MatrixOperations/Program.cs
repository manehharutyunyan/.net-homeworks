using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MatrixOperations
{

    class Program
    {

        static void Main(string[] args)
        {
            //int[,] a = { { 1, 2, 3 }, { 4, 5, 6 } };//, { 7, 8, 9 } };
            //int[,] b = { { 4, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };

            int[,] a = { { 1, 4, 2 }, { 2, 5, 1 } };
            int[,] b = { { 3, 4, 2 }, { 3, 5, 7 }, { 1, 2, 1 } };
            int[,] i = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            int[,] o = { { -1, 0}, { 0, 1 } };

            Matrix A = new Matrix(a, 2, 3);
            Matrix B = new Matrix(b, 3, 3);
            Matrix I = new Matrix(i, 3, 3);
            Matrix O = new Matrix(o, 2, 2);
            Matrix.Print(A);
            Console.WriteLine();
            Matrix.Print(B);

            //Console.WriteLine(Matrix.MinElement(A));
            //Matrix sum = Matrix.Add(I, B);
            //Matrix.Print(sum);
            //Matrix.Multiply(A, B);
            //Matrix.ScalarProduct(A, 10);
            //Matrix.TransposeMatrix(A);
            ///Console.WriteLine(Matrix.IsOrthogonal(A));
            //Console.WriteLine(Matrix.IsIdentity(I));
        }
    }
}
