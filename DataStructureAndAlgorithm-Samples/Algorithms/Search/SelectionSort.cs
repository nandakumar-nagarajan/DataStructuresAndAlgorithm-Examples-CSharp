/****************************** Module Header ******************************\
Module Name:  sort and search
Project:      Data structure and Algorithm
Copyright (c) Nandakumar Nagarajan.

Created At: 17-Aug-2018

-------------------------------Description-----------------------------------
                           Selection sort
------------------------------------------------------------------------------
The selection sort algorithm sorts an array by repeatedly finding the minimum element (considering ascending order) from unsorted part and putting it at the beginning.
The algorithm maintains two subarrays in a given array.

1) The subarray which is already sorted.
2) Remaining subarray which is unsorted.

In every iteration of selection sort, the minimum element (considering ascending order) from the unsorted subarray is picked and moved to the sorted subarray.

Time Complexity: O(n2) as there are two nested loops.

Auxiliary Space: O(1)
The good thing about selection sort is it never makes more than O(n) swaps and can be useful when memory write is a costly operation.

-----------------------------------------------------------------------------------------------
Pseudocode
-----------------------------------------------------------------------------------------------
arr[] = 64 25 12 22 11

// Find the minimum element in arr[0...4]
// and place it at beginning
11 25 12 22 64

// Find the minimum element in arr[1...4]
// and place it at beginning of arr[1...4]
11 12 25 22 64

// Find the minimum element in arr[2...4]
// and place it at beginning of arr[2...4]
11 12 22 25 64

// Find the minimum element in arr[3...4]
// and place it at beginning of arr[3...4]
11 12 22 25 64 

\***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm_Samples.Algorithms
{
    public partial class SearchAndSort
    {

        static int[] SelectionSort(int[] a)
        {
            int max_value;

            for (int i = 0; i < a.Length - 1; i++)
            {
                max_value = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[max_value])
                    {
                        max_value = j;
                    }
                }

                var temp = a[i];
                a[i] = a[max_value];
                a[max_value] = temp;
            }
            return a;
        }

        public static void SelectionSortAlgo()
        {
            Console.WriteLine("***************Selection Sort*****************");
            Console.WriteLine("Please enter the length of the array ");

            int max = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[max];

            Console.WriteLine("Please enter the array data");
            for (int i = 0; i < max; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }

            int[] b = SelectionSort(a);

            Console.WriteLine("The sorted array is....\n");
            foreach (int n in b)
            {
                Console.WriteLine(n);
            }

            Console.ReadKey();
        }
    }
}
