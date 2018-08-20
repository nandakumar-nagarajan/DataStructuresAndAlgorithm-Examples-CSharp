using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm_Samples.Algorithms.DivideAndConquer
{
    public partial class DivideAndConquer
    {

        static double[] PolinomialMultiply(double[] a,double[] b , int aMax, int bMax)
        {
            double[] c = new double[aMax + bMax - 1];

            for (int i = 0; i < aMax + bMax - 1; i++)
                c[i] = 0;

            for (int m = 0; m < aMax; m++)
                for (int n = 0; n < bMax; n++)
                    c[m + n] += a[m] * b[n];

            return c;
        }

        public static void MultiplyTwoPolynomial()
        {
            Console.WriteLine("***************Multiply 2 Polynomials******************");
            Console.WriteLine("Please enter First polynomial length");

            int aMax = Convert.ToInt32(Console.ReadLine());
            double[] a = new double[aMax];

            Console.WriteLine("Please enter Second Polynomial length");

            int bMax = Convert.ToInt32(Console.ReadLine());
            double[] b = new double[bMax];

            Console.WriteLine("Enter First Polynomial");
            for (int i=0; i<aMax; i++)
            {
                a[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Enter Second Polynomial");
            for (int i = 0; i < bMax; i++)
            {
                b[i] = Convert.ToDouble(Console.ReadLine());
            }


            double[] c = PolinomialMultiply(a, b, aMax, bMax);

            Console.WriteLine("The result is ... \n"); 
            foreach (double d in c)
            {
                Console.WriteLine(d);
            }

        }

    }
}
