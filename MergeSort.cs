/// ------------------------------------------------------------
/// Name: MergeSort
/// Author: Matthew Collard
/// Purpose: Construct the Merge Sort algorithm
/// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselineResources
{
    class MergeSort
    {
        static void Main(string[] args)
        {
            int[] aintArray = new int[] { 3, 2, 4, 9, 13, 11, 32, 1, 28 };
            BeginMergeSort(aintArray);
            Console.WriteLine(String.Join(",", aintArray));
            Console.ReadLine();
        }

        private static void BeginMergeSort(int[] aintArrayToSort)
        {
            // Anything to sort
            if (aintArrayToSort.Count() > 1)
            {
                int intMidpoint = aintArrayToSort.Length / 2;

                int[] aintLeftHalf = aintArrayToSort.Take(intMidpoint).ToArray();
                int[] aintRightHalf = aintArrayToSort.Skip(intMidpoint).ToArray();

                // Recursively sort and merge
                BeginMergeSort(aintLeftHalf);
                BeginMergeSort(aintRightHalf);

                int intLeftIndex = 0;
                int intRightIndex = 0;
                int intArrayIndex = 0;

                // Sort until we've reach the end of one half
                while (intLeftIndex < aintLeftHalf.Length && intRightIndex < aintRightHalf.Length)
                {
                    if (aintLeftHalf[intLeftIndex] < aintRightHalf[intRightIndex])
                    {
                        aintArrayToSort[intArrayIndex] = aintLeftHalf[intLeftIndex];
                        intLeftIndex += 1;
                    }
                    else
                    {
                        aintArrayToSort[intArrayIndex] = aintRightHalf[intRightIndex];
                        intRightIndex += 1;
                    }

                    intArrayIndex += 1;
                }

                // Append the unfinished and sorted other half w/ A or B loop

                // A
                while (intLeftIndex < aintLeftHalf.Length)
                {
                    aintArrayToSort[intArrayIndex] = aintLeftHalf[intLeftIndex];
                    intLeftIndex += 1;
                    intArrayIndex += 1;
                }

                while (intRightIndex < aintRightHalf.Length)
                {
                    aintArrayToSort[intArrayIndex] = aintRightHalf[intRightIndex];
                    intRightIndex += 1;
                    intArrayIndex += 1;
                }

            }
        }
    }
}
