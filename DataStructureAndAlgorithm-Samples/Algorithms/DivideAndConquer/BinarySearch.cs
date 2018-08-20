/****************************** Module Header ******************************\
Module Name:  DivideAndConquer Binary Search.cs
Project:      Data structure and Algorithm
Copyright (c) Nandakumar Nagarajan.

Created At: 30-jul-2018

-------------------------------Description-----------------------------------
                                Binary Search
------------------------------------------------------------------------------
Given a sorted array arr[] of n elements, write a function to search a given element x in arr[].

A simple approach is to do linear search.The time complexity of above algorithm is O(n). Another approach to perform the same
task is using Binary Search.

Binary Search: Search a sorted array by repeatedly dividing the search interval in half. Begin with an interval covering the whole
array. If the value of the search key is less than the item in the middle of the interval, narrow the interval to the lower half. 
Otherwise narrow it to the upper half. Repeatedly check until the value is found or the interval is empty.

-----------------------------------------------------------------------------------------------
Pseudocode
-----------------------------------------------------------------------------------------------
Algorithm: Binary-Search(numbers[], x, l, r)
if l = r then  
   return l  
else 
   m := [(l + r) / 2 ]
   if x ≤ numbers[m]  then 
      return Binary-Search(numbers[], x, l, m) 
   else 
      return Binary-Search(numbers[], x, m+1, r) 

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

        private static int BinarySearchWithoutRecursive(int[] a, int x, int left, int right)
        {
            int index = -1;

            if (left <= right)
            {
                if (left == right)
                {
                    return left;
                }
                else
                {
                    int mid = (left + right) / 2;

                    if (a[mid] >= x)
                        return BinarySearchWithoutRecursive(a, x, left, mid);
                    else if (a[mid] < x)
                        return BinarySearchWithoutRecursive(a, x, mid + 1, right);
                }
            }
            else
            {
                throw new Exception("minimum index cant higher than max index");
            }

            return index;
        }

        private static int BinarySearchWithRecursive(int[] a, int x, int left, int right)
        {
            int index = 0;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (x == a[mid])
                    return ++mid;
                else if (x < a[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return index;
        }

        public static void BinarySearch()
        {
            Console.WriteLine("**************Binary Search******************");
            Console.WriteLine("Please enter the max number of array item length.");

            try
            {
                int maxArray = Convert.ToInt32(Console.ReadLine());
                var array =new int[maxArray];
                string searchMode;
                int itemToSearch;
                int result=-1;

                Console.WriteLine("Please enter the array in sorted order.");

                for (int i = 0; i < maxArray; i++)
                {
                    Console.WriteLine("Enter item of index " + i);
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Please enter the item to be searched.");
                itemToSearch = Convert.ToInt32( Console.ReadLine());

                start:
                Console.WriteLine("Do you need binary search mode in Recursive(Y/N)");
                searchMode = Convert.ToString(Console.ReadLine());

                if (searchMode.ToUpper() == "Y" || searchMode.ToUpper() == "N")
                {

                    if (searchMode.ToUpper() == "Y")
                        result = BinarySearchWithRecursive(array, itemToSearch, 0, maxArray - 1);
                    else if(searchMode.ToUpper() == "N")
                        result= BinarySearchWithoutRecursive(array, itemToSearch, 0, maxArray - 1);
                }
                else
                    goto start;

                if (result == -1)
                    Console.WriteLine("The item not found in array");
                else
                    Console.WriteLine("The item found in the index " + result);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
