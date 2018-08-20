/****************************** Module Header ******************************\
Module Name:  DivideAndConquer Quick sort.cs
Project:      Data structure and Algorithm
Copyright (c) Nandakumar Nagarajan.

Created At: 09-Aug-2018

-------------------------------Description-----------------------------------
                                Quick Sort
------------------------------------------------------------------------------


The key process in quickSort is partition(). Target of partitions is, given an array and an element x of array as pivot, put x at its correct position in sorted array 
and put all smaller elements (smaller than x) before x, and put all greater elements (greater than x) after x. All this should be done in linear time.

-----------------------------------------------------------------------------------------------
Pseudocode
-----------------------------------------------------------------------------------------------
 //low  --> Starting index,  high  --> Ending index 
quickSort(arr[], low, high)
{
    if (low < high)
    {
         //pi is partitioning index, arr[pi] is now at right place 

        pi = partition(arr, low, high);

        quickSort(arr, low, pi - 1);  // Before pi
        quickSort(arr, pi + 1, high); // After pi
    }
}

partition (arr[], low, high)
{
    // pivot (Element to be placed at right position)
    pivot = arr[high];  
 
     // Index of smaller element
    i = (low - 1) 

    for (j = low; j <= high- 1; j++)
    {
        // If current element is smaller than or equal to pivot
        if (arr[j] <= pivot)
        {
            i++;    // increment index of smaller element
            swap arr[i] and arr[j]
        }
    }
    swap arr[i + 1] and arr[high])
    return (i + 1)
}
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

        private static int Partion(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j =left; j < right; j++)
            {
                if(array[j] <= pivot)
                {
                    i++;

                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            var temp1 = array[i + 1];
            array[i + 1] = array[right];
            array[right] = temp1;

            return i + 1;
        }


        public static void sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pi = Partion(array,left, right);

                sort(array,left, pi - 1);
                sort(array,pi + 1, right);

            }
        }

        public static void sortWithoutRecursion(int[] array, int left, int right)
        {
            int pivot, leftend, rightend;

            leftend = left;
            rightend = right;
            pivot = array[left];

            while (left < right)
            {
                while ((array[right] >= pivot) && (left < right))
                {
                    right--;
                }

                if (left != right)
                {
                    array[left] = array[right];
                    left++;
                }

                while ((array[left] >= pivot) && (left < right))
                {
                    left++;
                }

                if (left != right)
                {
                    array[right] = array[left];
                    right--;
                }
            }

            array[left] = pivot;
            pivot = left;
            left = leftend;
            right = rightend;

            if (left < pivot)
            {
                sortWithoutRecursion(array, left, pivot - 1);
            }
            if (right > pivot)
            {
                sortWithoutRecursion(array,pivot + 1, right);
            }
        }

        static public void QuickSortMain()
        {
            start:
            Console.WriteLine("********** Quick Sort Algo ********");
            Console.WriteLine("Please enter the size of array");

            string sortMode;
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
                startQuick:
                Console.WriteLine("Do you need sort mode in Recursive(Y/N)");
                sortMode = Convert.ToString(Console.ReadLine());

                if (sortMode.ToUpper() == "Y" || sortMode.ToUpper() == "N")
                {
                    if (sortMode.ToUpper() == "Y")
                        sort(unsorted, 0, unsorted.Length - 1);
                    else if (sortMode.ToUpper() == "N")
                        sortWithoutRecursion(unsorted,0, unsorted.Length - 1);
                }
                else
                    goto startQuick;

                Console.WriteLine("Quick sort result is \n");
                foreach (int k in unsorted)
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
