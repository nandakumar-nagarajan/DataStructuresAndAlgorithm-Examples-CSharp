/****************************** Module Header ******************************\
Module Name:  DivideAndConquer MergeSort.cs
Project:      Data structure and Algorithm
Copyright (c) Nandakumar Nagarajan.

Created At: 30-jul-2018

-------------------------------Description-----------------------------------
                                Merge sort 
------------------------------------------------------------------------------
Merge Sort is one of the popular sorting algorithms in C# as it uses the minimum number of comparisons.

Merge sort is a sorting technique based on divide and conquer technique. With worst-case time complexity being
Ο(n log n), it is one of the most respected algorithms.

Merge sort first divides the array into equal halves and then combines them in a sorted manner.

Step 1 − if it is only one element in the list it is already sorted, return.
Step 2 − divide the list recursively into two halves until it can no more be divided.
Step 3 − merge the smaller lists into new list in sorted order.

-----------------------------------------------------------------------------------------------
Pseudocode
-----------------------------------------------------------------------------------------------
procedure mergesort( var a as array )
   if ( n == 1 ) return a

   var l1 as array = a[0] ... a[n/2]
   var l2 as array = a[n/2+1] ... a[n]

   l1 = mergesort( l1 )
   l2 = mergesort( l2 )

   return merge( l1, l2 )
end procedure

procedure merge( var a as array, var b as array )

   var c as array
   while ( a and b have elements )
      if ( a[0] > b[0] )
         add b[0] to the end of c
         remove b[0] from b
      else
         add a[0] to the end of c
         remove a[0] from a
      end if
   end while
   
   while ( a has elements )
      add a[0] to the end of c
      remove a[0] from a
   end while
   
   while ( b has elements )
      add b[0] to the end of c
      remove b[0] from b
   end while
   
   return c
	
end procedure

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
        /// <summary>
        /// merge the halves to single by asc order of value
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static List<int> MainMerge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.FirstOrDefault() <= right.FirstOrDefault())
                    {
                        result.Add(left.FirstOrDefault());
                        left.Remove(left.FirstOrDefault());
                    }
                    else
                    {
                        result.Add(right.FirstOrDefault());
                        right.Remove(right.FirstOrDefault());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.FirstOrDefault());
                    left.Remove(left.FirstOrDefault());
                }
                else
                {
                    result.Add(right.FirstOrDefault());
                    right.Remove(right.FirstOrDefault());
                }
                
            }

            return result;
        }

        /// <summary>
        /// Recurrsive function to split the array until index length to 1 
        /// </summary>
        /// <param name="unsorted"></param>
        /// <returns></returns>
        private static List<int> SortMerge(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            int middle = unsorted.Count / 2;

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0;i<middle;i++ )
            {
                left.Add(unsorted[i]);
            }
            for(int j=middle;j<unsorted.Count; j++)
            {
                right.Add(unsorted[j]);
            }

            left = SortMerge(left);
            right = SortMerge(right);

            return MainMerge(left,right);
        }

        /// <summary>
        /// Merge sort main function
        /// Get input array
        /// </summary>
        public static void MergeSort()
        {
            start:
            Console.WriteLine("********** Merge sort Algo ********");
            Console.WriteLine("Please enter the size of array");

            List<int> sorted = new List<int>();
            short maxSize;
            var validInt = Int16.TryParse(Console.ReadLine(), out maxSize);

            if (validInt)
            {
                int[] unsorted = new int[maxSize];

                ///Read the array elements from user 
                for (int i = 0; i < maxSize; i++)
                {
                    Console.WriteLine("please enter index {0} number", i);
                    unsorted[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("The array elements are...\n");
                ///show the array elements 
                foreach (int j in unsorted)
                {
                    Console.WriteLine(j + "\n");
                }

                //sort the array 
                sorted=SortMerge(unsorted.ToList());

                Console.WriteLine("Merge sort result is \n");
                foreach (int k in sorted)
                {
                    Console.WriteLine(k + "\n");
                }
                System.Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please enter valid number");
                goto start;
            }

        }
    }
}
