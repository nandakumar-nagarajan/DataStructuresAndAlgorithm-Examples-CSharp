/****************************** Module Header ******************************\
Module Name:  DivideAndConquer Strassen's matrix multiplication.cs
Project:      Data structure and Algorithm
Copyright (c) Nandakumar Nagarajan.

Created At: 10-Aug-2018

-------------------------------Description-----------------------------------
                               strassen's Matrix multiplication
------------------------------------------------------------------------------
Divide and Conquer 
Following is simple Divide and Conquer method to multiply two square matrices.
1) Divide matrices A and B in 4 sub-matrices of size N/2 x N/2 as shown in the below diagram.
2) Calculate following values recursively. ae + bg, af + bh, ce + dg and cf + dh.

In the above divide and conquer method, the main component for high time complexity is 8 recursive calls. The idea of Strassen’s method is to reduce the number of recursive calls to 7.
Strassen’s method is similar to above simple divide and conquer method in the sense that this method also divide matrices to sub-matrices of size N/2 x N/2 as shown in the above diagram, 
but in Strassen’s method, the four sub-matrices of result are calculated using following formulae.

Generally Strassen’s Method is not preferred for practical applications for following reasons.
1) The constants used in Strassen’s method are high and for a typical application Naive method works better.
2) For Sparse matrices, there are better methods especially designed for them.
3) The submatrices in recursion take extra space.
4) Because of the limited precision of computer arithmetic on noninteger values, larger errors accumulate in Strassen’s algorithm than in Naive Method (Source: CLRS Book)

-----------------------------------------------------------------------------------------------
Pseudocode
-----------------------------------------------------------------------------------------------
//Simple multiplication

void multiply(int A[][N], int B[][N], int C[][N])
{
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < N; j++)
        {
            C[i][j] = 0;
            for (int k = 0; k < N; k++)
            {
                C[i][j] += A[i][k]*B[k][j];
            }
        }
    }
}
Time Complexity of above method is O(N3).

A11 A12
A22 A21
⨉
B11 B12
B22 B21
=
C11 C12
C21 C22

P1 = (A11 + A22)(B11 + B22)
P2 = (A21 + A22)B11
P3 = A11(B12 − B22)
P4 = A22(B21 − B11)
P5 = (A11 + A12)B22
P6 = (A21 − A11)(B11 + B12)
P7 = (A12 − A22)(B21 + B22)

C11 = P1 + P4 − P5 + P7
C12 = P3 + P5
C21 = P2 + P4
C22 = P1 − P2 + P3 + P6
Uses only 7 multiplications!

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm_Samples.Algorithms.DivideAndConquer
{
    public partial class DivideAndConquer
    {
        private static Matrix SimpleMatrixMultiplication(Matrix a,Matrix b,int m,int n)
        {
            Matrix c = new Matrix(m,n);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = 0;

                    for (int k = 0; k < n; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return c;
        }

        public static void MatrixMultiplication()
        {
            int i, j, m, n;
            Console.WriteLine("Enter the Number of Rows and Columns : ");
            m = Convert.ToInt32(Console.ReadLine());
            n = m;
            var a = new Matrix(m);
            Console.WriteLine("Enter the First Matrix");
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    a[i, j] =  Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("First matrix is:");
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
            var b = new Matrix(m);
            Console.WriteLine("Enter the Second Matrix");
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    b[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Second Matrix is :");
            for (i = 0; i < 2; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    Console.Write(b[i, j] + "\t");
                }
                Console.WriteLine();
            }


            start:
            Console.WriteLine("Do you need multiplication in Strassen's Mode(Y/N)");
            var searchMode = Convert.ToString(Console.ReadLine());
            var c = new Matrix(m);

            if (searchMode.ToUpper() == "Y" || searchMode.ToUpper() == "N")
            {

                if (searchMode.ToUpper() == "Y")
                {
                    c = Matrix.StrassenMultiply(a, b);
                }
                else if (searchMode.ToUpper() == "N")
                {
                    c = SimpleMatrixMultiplication(a, b, m, n);
                }

            }
            else
                goto start;


            Console.WriteLine("Matrix Multiplication is :");
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(c[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }

    public sealed class Matrix
    {
        #region Private variables and fields
        public int Rows
        {
            get
            {
                return values.GetLength(0);
            }
        }
        public int Columns
        {
            get
            {
                return values.GetLength(1);
            }
        }

        private double[,] values;
        public double this[int row, int col]
        {
            get
            {
                return values[row, col];
            }
            set
            {
                values[row, col] = value;
            }
        }
        #endregion

        #region Constructors
        public Matrix(int m, int n)
        {
            if (m <= 0)
                throw new ArgumentOutOfRangeException("m is less than or equal to zero.");
            if (n <= 0)
                throw new ArgumentOutOfRangeException("n is less than or equal to zero.");

            values = new double[m, n];
        }

        public Matrix(int m) : this(m, m) { }

        public Matrix(double[,] values)
        {
            if (values == null)
                throw new ArgumentNullException("values == null.");

            this.values = values;
        }
        #endregion

        #region Overriden methods
        public override bool Equals(object obj)
        {
            Matrix a = this, b = (Matrix)obj;

            if (b == null)
                return false;
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                return false;

            for (int row = 0; row < a.Rows; row++)
                for (int col = 0; col < a.Columns; col++)
                    if (a[row, col] != b[row, col]) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Operators
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Add(a, b);
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.Subtract(a, b);
        }
        #endregion

        public static Matrix Add(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Not identical matrices.");

            Matrix result = new Matrix(a.Rows, a.Columns);

            for (int row = 0; row < a.Rows; row++)
                for (int col = 0; col < a.Columns; col++)
                    result[row, col] = a[row, col] + b[row, col];

            return result;
        }

        public static Matrix Subtract(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Not identical matrices.");

            Matrix result = new Matrix(a.Rows, a.Columns);

            for (int row = 0; row < a.Rows; row++)
                for (int col = 0; col < a.Columns; col++)
                    result[row, col] = a[row, col] - b[row, col];

            return result;
        }

        public static Matrix NormalMultiply(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
                throw new ArgumentException("Number of rows of the matrix a doesnt equal to number of columns of the matrix b.");

            Matrix result = new Matrix(a.Rows, b.Columns);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < b.Columns; col++)
                {
                    double tmp = 0;
                    for (int i = 0; i < a.Columns; i++) // or i < b.Rows, it's equal
                        tmp += a[row, i] * b[i, col];

                    result[row, col] = tmp;
                }
            }

            return result;
        }

        public static Matrix StrassenMultiply(Matrix a, Matrix b)
        {
            // TODO If the matrices A, B are not of type 2n x 2n we fill the missing rows and columns with zeros.
            var sizes = new int[] { a.Rows, a.Columns, b.Rows, b.Columns };
            if (sizes.Distinct().Count() != 1 || (a.Rows & (a.Rows - 1)) != 0)
                throw new ArgumentException("Not identical or square matrices.");

            int N = b.Rows;
            if (N <= 48)
                return NormalMultiply(a, b);

            int halfN = N / 2;

            var a11 = a.SubMatrix(0, halfN, 0, halfN);
            var a12 = a.SubMatrix(0, halfN, halfN, N);
            var a21 = a.SubMatrix(halfN, N, 0, halfN);
            var a22 = a.SubMatrix(halfN, N, halfN, N);

            var b11 = b.SubMatrix(0, halfN, 0, halfN);
            var b12 = b.SubMatrix(0, halfN, halfN, N);
            var b21 = b.SubMatrix(halfN, N, 0, halfN);
            var b22 = b.SubMatrix(halfN, N, halfN, N);

            Matrix[] m = new Matrix[]{
                StrassenMultiply(a11 + a22, b11 + b22),     // m1
                StrassenMultiply(a21 + a22, b11),           // m2
                StrassenMultiply(a11, b12 - b22),           // m3
                StrassenMultiply(a22, b21 - b11),           // m4
                StrassenMultiply(a11 + a12, b22),           // m5
                StrassenMultiply(a21 - a11, b11 + b12),     // m6
                StrassenMultiply(a12 - a22, b21 + b22),     // m7
            };

            var c11 = m[0] + m[3] - m[4] + m[6];
            var c12 = m[2] + m[4];
            var c21 = m[1] + m[3];
            var c22 = m[0] - m[1] + m[2] + m[5];

            return CombineSubMatrices(c11, c12, c21, c22);
        }

        private Matrix SubMatrix(int rowFrom, int rowTo, int colFrom, int colTo)
        {
            Matrix result = new Matrix(rowTo - rowFrom, colTo - colFrom);
            for (int row = rowFrom, i = 0; row < rowTo; row++, i++)
                for (int col = colFrom, j = 0; col < colTo; col++, j++)
                    result[i, j] = values[row, col];
            return result;
        }

        private static Matrix CombineSubMatrices(Matrix a11, Matrix a12, Matrix a21, Matrix a22)
        {
            Matrix result = new Matrix(a11.Rows * 2);
            int shift = a11.Rows;
            for (int row = 0; row < a11.Rows; row++)
                for (int col = 0; col < a11.Columns; col++)
                {
                    result[row, col] = a11[row, col];
                    result[row, col + shift] = a12[row, col];
                    result[row + shift, col] = a21[row, col];
                    result[row + shift, col + shift] = a22[row, col];
                }
            return result;
        }
    }
}
