/****************************** Module Header ******************************\
Module Name:  DivideAndConquer -> Cooley-Tukey fast fourier transformation .cs
Project:      Data structure and Algorithm
Copyright (c) Nandakumar Nagarajan.

Created At: 16-Aug-2018

-------------------------------Description-----------------------------------
                   Cooley-Tukey fast fourier transformation 
------------------------------------------------------------------------------
The Cooley–Tukey algorithm, named after J. W. Cooley and John Tukey, is the most common fast Fourier transform (FFT) algorithm. It re-expresses the discrete Fourier transform (DFT)
of an arbitrary composite size N = N1N2 in terms of N1 smaller DFTs of sizes N2, recursively, to reduce the computation time to O(N log N) for highly composite N (smooth numbers).
Because of the algorithm's importance, specific variants and implementation styles have become known by their own names, as described below.

Let us take for n=8 and procede for formation of iterative fft algorithm. Looking at the recursion tree above, we find that if we arrange the elements of the initial coefficient vector a 
into the order in which they appear in the leaves, we could trace the execution of the Recusive-FFT procedure, but bottom up instead of top down. First, we take the elements in pairs, 
compute the DFT of each pair using one butterfly operation, and replace the pair with its DFT. The vector then holds n/2 2-element DFTs. Next, we take these n/2 DFTs in pairs and compute the 
DFT of the four vector elements they come from by executing two butterfy operations, replacing two 2-element DFTs with one 4-element DFT. The vector then holds n/4 4-element DFTs. We continue 
in this manner until the vector holds two (n/2) element DFTs, which we combine using n/2 butterfly operations into the final n-element DFT.

-----------------------------------------------------------------------------------------------
Pseudocode
-----------------------------------------------------------------------------------------------
To turn this bottom-up approach into code, we use an array A[0…n] that initially holds the elements of the input vector a in the order in which they appear in the leaves of the tree. 
Because we have to combine DFT so n each level of the tree, we introduce avariable s to count the levels, ranging from 1 (at the bottom, when we are combining pairs to form 2-element DFTs) 
to lgn (at the top, when weare combining two n/2 element DFTs to produce the final result). The algorithm therefore is:

1. for s=1 to lgn
2.     do for k=0 to n-1 by  2^s 
3.           do combine the two  2^s-1   -element DFTs in
                A[k...k+ 2^s-1 -1] and A[k+2^s-1...k+2^s-1]
                into one 2s-element DFT in A[k...k+2^s-1]

Now for generating the code, we arrange the coefficient vector elements in the order of leaves. Example- The order in leaves 0, 4, 2, 6, 1, 5, 3, 7 is a bit reversal of the indices. 
Start with 000, 001, 010, 011, 100, 101, 110, 111 and reverse the bits of each binary number to obtain 000, 100, 010, 110, 001, 101, 011, 111.Pseudo code for iterative FFT :

BIT-REVERSE-COPY(a, A)
n = length [a]
for k = 0 to n-1
        do A[rev(k)] = a[k]
 
ITERATIVE-FFT
BIT-REVERSE-COPY(a, A)
n = length(a)
for s = 1 to log n
        do m= 2^s
      w_m = e^(2*PI*i/m)  
           for j = 0 to m/2-1
               do for k = j to n-1 by m
                      do t = wA[k+m/2]
                         u = A[k]
                         A[k] = u+t
                         A[k+m/2] = u-t 
w = w*w_n 
return A

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace DataStructureAndAlgorithm_Samples.Algorithms.DivideAndConquer
{
    public partial class DivideAndConquer
    {
        /* Performs a Bit Reversal Algorithm on a postive integer 
        * for given number of bits
        * e.g. 011 with 3 bits is reversed to 110 */
        public static int BitReversal(int n, int bits)
        {
            int reversedN = n;
            int count = bits - 1;

            n >>= 1;
            while (n > 0)
            {
                reversedN = (reversedN << 1) | (n & 1);
                count--;
                n >>= 1;
            }

            return ((reversedN << count) & ((1 << bits) - 1));
        }

        /* Uses Cooley-Tukey iterative in-place algorithm with radix-2 DIT case
        * assumes no of points provided are a power of 2 */
        public static void FastFourierTransformation(Complex[] buffer)
        {
            int bits = (int)Math.Log(buffer.Length, 2);
            for (int j = 1; j < buffer.Length / 2; j++)
            {
                int swapPos = BitReversal(j, bits);
                var temp = buffer[j];
                buffer[j] = buffer[swapPos];
                buffer[swapPos] = temp;
            }

            for (int N = 2; N <= buffer.Length; N <<= 1)
            {
                for (int i = 0; i < buffer.Length; i += N)
                {
                    for (int k = 0; k < N / 2; k++)
                    {

                        int evenIndex = i + k;
                        int oddIndex = i + k + (N / 2);
                        var even = buffer[evenIndex];
                        var odd = buffer[oddIndex];

                        double term = -2 * Math.PI * k / (double)N;
                        Complex exp = new Complex(Math.Cos(term), Math.Sin(term)) * odd;

                        buffer[evenIndex] = even + exp;
                        buffer[oddIndex] = even - exp;

                    }
                }
            }

        }

        static public void CooleyTukeyFTT()
        {
            Console.WriteLine("********** Cooley Tukey Fast Fourier Transform  ********");
            Console.WriteLine("Please enter the length of the array.");

            //A complex number is a number that comprises a real number part and an imaginary number part. A complex number z is usually written in the form z = x + yi, where x and y are 
            //real numbers, and i is the imaginary unit that has the property i2 = -1. The real part of the complex number is represented by x, and the imaginary part of the complex number 
            //is represented by y.

            //The Complex type uses the Cartesian coordinate system(real, imaginary) when instantiating and manipulating complex numbers. 

            int max = Convert.ToInt32(Console.ReadLine());
            Complex[] complex = new Complex[max];

            Console.WriteLine("Please enter the numbers... \n");
            for (int i = 0; i < max; i++)
            {
                complex[i] = Convert.ToDouble(Console.ReadLine());
            }

            FastFourierTransformation(complex);

            Console.WriteLine("The Result is... \n");
            foreach (Complex a in complex)
            {
                Console.WriteLine(a);
            }

        }

    }
}
