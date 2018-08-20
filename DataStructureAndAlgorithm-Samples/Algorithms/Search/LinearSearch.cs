/****************************** Module Header ******************************\
Module Name:  sort and search
Project:      Data structure and Algorithm
Copyright (c) Nandakumar Nagarajan.

Created At: 30-jul-2018

-------------------------------Description-----------------------------------
                                Linear Search
------------------------------------------------------------------------------
Linear search is a very simple search algorithm. In this type of search, a sequential search is made over all items one by one. Every item is checked
and if a match is found then that particular item is returned, otherwise the search continues till the end of the data collection.

-----------------------------------------------------------------------------------------------
Pseudocode
-----------------------------------------------------------------------------------------------

procedure linear_search (list, value)

   for each item in the list
      if match item == value
         return the item's location
      end if
   end for

end procedure

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
        private static int LinearSearchIndex(int[] a , int x)
        {
            int index = -1;
            int j = 0;
            foreach (int i in a)
            {
                j++;
                if (i == x)
                    return j;
            }
            return index;
        }
        public static void LinearSearch()
        {
            Console.WriteLine("**************Linear Search******************");
            Console.WriteLine("Please enter the max number of array item length.");

            try
            {
                int maxArray = Convert.ToInt32(Console.ReadLine());
                var array = new int[maxArray];
                int itemToSearch;

                Console.WriteLine("Please enter the array in sorted order.");

                for (int i = 0; i < maxArray; i++)
                {
                    Console.WriteLine("Enter item of index " + i);
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Please enter the item to be searched.");
                itemToSearch = Convert.ToInt32(Console.ReadLine());

                int result = LinearSearchIndex(array, itemToSearch);

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
