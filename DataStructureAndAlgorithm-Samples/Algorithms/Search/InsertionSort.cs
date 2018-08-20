/****************************** Module Header ******************************\
Module Name:  sort and search
Project:      Data structure and Algorithm
Copyright (c) Nandakumar Nagarajan.

Created At: 17-Aug-2018

-------------------------------Description-----------------------------------
                          Insertion sort
------------------------------------------------------------------------------
Insertion sort is a simple sorting algorithm that works the way we sort playing cards in our hands.
The Insertion sort algorithm views the data in two halves.
The left half of sorted elements and the right half of elements to be sorted.
In each iteration, one element from the right half is taken and added to the left half so that the left half is still sorted.
Insertion sort takes an element from the list and places it in the correct location in the list.
This process is repeated until there are no more unsorted items in the list.

Time Complexity: O(n*n)

Auxiliary Space: O(1)

Boundary Cases: Insertion sort takes maximum time to sort if elements are sorted in reverse order. And it takes minimum time (Order of n) when elements are already sorted.

Algorithmic Paradigm: Incremental Approach



-----------------------------------------------------------------------------------------------
Pseudocode
-----------------------------------------------------------------------------------------------
12, 11, 13, 5, 6

Let us loop for i = 1 (second element of the array) to 5 (Size of input array)

i = 1. Since 11 is smaller than 12, move 12 and insert 11 before 12
11, 12, 13, 5, 6

i = 2. 13 will remain at its position as all elements in A[0..I-1] are smaller than 13
11, 12, 13, 5, 6

i = 3. 5 will move to the beginning and all other elements from 11 to 13 will move one position ahead of their current position.
5, 11, 12, 13, 6

i = 4. 6 will move to position after 5, and elements from 11 to 13 will move one position ahead of their current position.
5, 6, 11, 12, 13

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
        public static int[] InsertionSortAlgoType1(int[] a)
        {
            int n = a.Length;
            int key,j;
            for (int i = 1; i < n; i++)
            {
                key = a[i];
                j = i - 1;

                while (j >= 0 && a[j] > key)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = key;
            }
            return a;
        }

        public static int[] InsertionSortAlgoType2(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                var item = a[i];
                int k = 0;
                for (int j = i - 1; j >= 0 && k != 0;)
                {
                    if (a[j] > item)
                    {
                        a[j + 1] = a[j];
                        j--;
                        a[j + 1] = item;
                    }
                    else k = 1;
                }
            }
            return a;
        }

        static public void InsertionSort()
        {
                Console.WriteLine("***************Insertion Sort*****************");
                Console.WriteLine("Please enter the length of the array ");

                int max = Convert.ToInt32(Console.ReadLine());
                int[] a = new int[max];

                Console.WriteLine("Please enter the array data");
                for (int i = 0; i < max; i++)
                {
                    a[i] = Convert.ToInt32(Console.ReadLine());
                }

                int[] b = InsertionSortAlgoType1(a);

                Console.WriteLine("The sorted array is....\n");
                foreach (int n in b)
                {
                    Console.WriteLine(n);
                }

            Console.ReadKey();
        }

    }
}
