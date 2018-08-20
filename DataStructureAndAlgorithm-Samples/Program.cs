using DataStructureAndAlgorithm_Samples.Algorithms;
using DataStructureAndAlgorithm_Samples.Algorithms.DivideAndConquer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm_Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.WriteLine("Data structures and Algorithm \n");

            Console.WriteLine("" +
                "Please enter the Algorithm paradigm number. \n" +
                "*******************************************\n"+
                "1. Divide and Conqure \n" +
                "2. Greedy Algorithms \n" +
                "3. Dynamic Programming \n" +
                "4. Search And Sort Algorithms \n" +
                "5. Other Algorithms \n" +
                "6. Exit \n"+
                "******************************************* \n\n" +
                "Please enter your choice\n"

                );

            int algoSec = Convert.ToInt16(Console.ReadLine());
            int algoNum;
            switch (algoSec)
            {
                case 1: 
                        Console.WriteLine(
                        "Divide And Conqure \n \n" +
                        "******************\n" +
                        "1. Binary Search \n" +
                        "2. Merge Sort \n"+
                        "3. Quick Sort \n"+
                        "4. Closest Pair of Points \n"+
                        "5. Strassen's Matrix Multiplication \n"+
                        "6. Karatsuba Multiplication \n"+
                        "7. Cooley-Tukey Fast Fourier Transformation \n"+
                        "8. Multiply 2 Polynomials \n" +
                        "******************" +
                         "\n Please enter the Algorithm Number. \n" 
                        );

                    algoNum= Convert.ToInt16(Console.ReadLine());

                    switch (algoNum)
                    {
                        case 1:
                            DivideAndConquer.BinarySearch();
                            goto start;
                           
                        case 2:
                            DivideAndConquer.MergeSort();
                            goto start;

                        case 3:
                            DivideAndConquer.QuickSortMain();
                            goto start;

                        case 4:
                            DivideAndConquer.ClosestPairOfPoint();
                            goto start;

                        case 5:
                            DivideAndConquer.MatrixMultiplication();
                            goto start;
                            
                        case 6:
                            DivideAndConquer.KaratsubaMultiplication();
                            goto start;

                        case 7:
                            DivideAndConquer.CooleyTukeyFTT();
                            goto start;

                        case 8:
                            DivideAndConquer.MultiplyTwoPolynomial();
                            goto start;

                    }

                    break;
                case 2:
                    Console.WriteLine(
                    "Greedy Algorithm \n \n" +
                    "*****************\n" +
                    "1. \n" +
                    "******************" +
                     "\n Please enter the Algorithm Number. \n"
                    );
                    algoNum = Convert.ToInt16(Console.ReadLine());

                    switch (algoNum)
                    {
                        case 1:
                            goto start;

                    }

                    break;
                case 3:
                    Console.WriteLine(
                    "Dynamic Programming\n \n" +
                    "*****************\n" +
                    "1. \n" +
                    "******************" +
                     "\n Please enter the Algorithm Number. \n"
                    );
                    algoNum = Convert.ToInt16(Console.ReadLine());

                    switch (algoNum)
                    {
                        case 1:
                            goto start;

                    }

                    break;
                case 4:
                    Console.WriteLine(
                    "Search and Sorting Algorithm \n \n" +
                    "*****************************\n" +
                    "1. Linear Search \n" +
                    "2. Selection Sort \n" +
                    "3. Insertion Sort \n" +
                    "******************" +
                     "\n Please enter the Algorithm Number. \n"
                    );
                    algoNum = Convert.ToInt16(Console.ReadLine());

                    switch (algoNum)
                    {
                        case 1:
                            SearchAndSort.LinearSearch();
                            goto start;
                        case 2:
                            SearchAndSort.SelectionSortAlgo();
                            goto start;
                        case 3:
                            SearchAndSort.InsertionSort();
                            goto start;

                    }
                    break;
                case 5:
                    Console.WriteLine(
                    "Other Algorithms \n \n" +
                    "****************\n" +
                    "1.  \n" +
                    "******************" +
                     "\n Please enter the Algorithm Number. \n"
                    );
                    algoNum = Convert.ToInt16(Console.ReadLine());

                    switch (algoNum)
                    {
                        case 1:
                            goto start;

                    }
                    break;

                case 6:
                    Environment.Exit(0);
                    break;
            }
        
        }
    }
}
