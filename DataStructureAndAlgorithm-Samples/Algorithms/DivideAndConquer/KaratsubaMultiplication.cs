/****************************** Module Header ******************************\
Module Name:  DivideAndConquer Karatsuba multiplication.cs
Project:      Data structure and Algorithm
Copyright (c) Nandakumar Nagarajan.

Created At: 14-Aug-2018

-------------------------------Description-----------------------------------
                           Karatsuba multiplication
------------------------------------------------------------------------------
For Systems long multiplication is too slow. These systems may employ Karatsuba multiplication, which was discovered in 1960 (published in 1962). The heart of Karatsuba's method lies in the 
observation that two-digit multiplication can be done with only three rather than the four multiplications classically required. This is an example of what is now called a divide and conquer
algorithm. Suppose we want to multiply two 2-digit base-m numbers: x1 m + x2 and y1 m + y2:

compute x1 · y1, call the result F
compute x2 · y2, call the result G
compute (x1 + x2) · (y1 + y2), call the result H
compute H − F − G, call the result K; this number is equal to x1 · y2 + x2 · y1
compute F · m2 + K · m + G.

To compute these three products of m-digit numbers, we can employ the same trick again, effectively using recursion. Once the numbers are computed, we need to add them together (steps 4 and 5),
which takes about n operations.

Karatsuba multiplication has a time complexity of O(nlog23) ≈ O(n1.585), making this method significantly faster than long multiplication. Because of the overhead of recursion, Karatsuba's 
multiplication is slower than long multiplication for small values of n; typical implementations therefore switch to long multiplication if n is below some threshold.

-----------------------------------------------------------------------------------------------
Pseudocode 
-----------------------------------------------------------------------------------------------
//karatsuba multiplication Formula

X= Xl * 2^n/2 + (Xr)
Y= Yl * 2^n/2 + (Yr)

XY= (Xl* 2^n/2 + Xr ) (Yl * 2^n/2 + Yr);
XY = 2^n (XlYl) + 2^n/2 ((XlYr)+(XrYl)) + (XrYr)

XlYr + XrYl = (Xl+Xr)(Yl+Yr)-XlYl-XrYr

XY = 2^n XlYl + 2^n/2 ((Xl+Xr)(Yl+Yr)-XlYl - XrYr) + XrYr

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DataStructureAndAlgorithm_Samples.Algorithms.DivideAndConquer
{
    public partial class DivideAndConquer
    {
        public static BigInteger Karatsuba(BigInteger x, BigInteger y)
        {
            BigInteger z = 0;

            //Returns the logarithm of a specified number in a specified base.
            int n = (int)Math.Max(BigInteger.Log(x, 2), BigInteger.Log(y, 2));

            if (n <= 10000)
                return x * y;

            n = ((n + 1) / 2);

            BigInteger b = x >> n;
            BigInteger a = x - (b << n);
            BigInteger d = y >> n;
            BigInteger c = y - (d << n);

            BigInteger ac = Karatsuba(a, b);
            BigInteger bd = Karatsuba(b, d);
            BigInteger abcd = Karatsuba(a + b, c + d);

            z = ac + (abcd - ac - bd) + (bd << (2 * n));

            return z;

        }

        public static void KaratsubaMultiplication()
        {
            Console.WriteLine("********** Karatsuba  ********");
            Console.WriteLine("Please enter the numbers to multiply.");

            Console.WriteLine("Enter the First Digit \n");
            BigInteger x = BigInteger.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Second Digit \n");
            BigInteger y = BigInteger.Parse(Console.ReadLine());

            BigInteger z = 0;
            z = Karatsuba(x, y);

            Console.WriteLine("The Multiplication Result is {0}",z);
            Console.ReadKey();

        }
    }
}
