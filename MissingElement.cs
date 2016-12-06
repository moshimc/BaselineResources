using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselineResources
{
    class MissingElement
    {
        private static void Main(string[] args)
        {
            int[] aintArrayOne = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int[] aintArrayTwo = new int[] { 1, 2, 3, 4, 5, 6 };
            int intElement = 0;
            intElement = FindTheMissingElement_VersionTwo(aintArrayOne, aintArrayTwo);
            Console.WriteLine("Missing Element: " + intElement.ToString());
            Console.ReadLine();
        }


        // ------------------------------------------------------------
        // Name: FindTheMissingElement_VersionOne
        // Purpose: Loop through both sorted arrays at the same time to
        //          determine the missing element
        // ------------------------------------------------------------
        private static int FindTheMissingElement_VersionOne(int[] aintArrayOne, int[] aintArrayTwo)
        {
            int intMissingElement = 0;
            int[] aintSmallArray = null;
            int[] aintLargeArray = null;

            // Sort the arrays
            Array.Sort(aintArrayOne);
            Array.Sort(aintArrayTwo);

            // The array with the smaller length determines our loop
            if (aintArrayOne.Length > aintArrayTwo.Length)
            {
                aintSmallArray = aintArrayTwo;
                aintLargeArray = aintArrayOne;
            }
            else
            {
                aintSmallArray = aintArrayOne;
                aintLargeArray = aintArrayTwo;
            }

            // Compare the elements in the sorted arrays
            for (int intIndex = 0; intIndex < aintSmallArray.Length; intIndex++)
            {
                if (aintSmallArray[intIndex] != aintLargeArray[intIndex])
                {
                    intMissingElement = aintLargeArray[intIndex];
                }
            }

            // If we didn't find any missing elements, it must be the last of 
            // the large array
            if (intMissingElement == 0) intMissingElement = aintLargeArray[aintLargeArray.Length - 1];

            return intMissingElement;
        }


        // ------------------------------------------------------------
        // Name: FindTheMissingElement_VersionTwo
        // Purpose: Add array elements to a dictionary for the first (smaller)
        //          array, and subtract from counts with the second (larger)
        //          if we decrement a count to -1 we know it's our missing element
        // ------------------------------------------------------------
        private static int FindTheMissingElement_VersionTwo(int[] aintArrayOne, int[] aintArrayTwo)
        {
            int intMissingElement = 0;
            Dictionary<int, int> dctElementCounts = new Dictionary<int, int>();
            int intCurrentValue = 0;

            // Assume aintArrayTwo is smaller for this exercise
            foreach (int intElement in aintArrayTwo)
            {
                dctElementCounts.TryGetValue(intElement, out intCurrentValue);

                dctElementCounts[intElement] = intCurrentValue + 1;
            }

            // Loop through second, larger array
            foreach (int intElement in aintArrayOne)
            {
                dctElementCounts.TryGetValue(intElement, out intCurrentValue);

                if (intCurrentValue == 0)
                {
                    intMissingElement = intElement;
                }
                else
                {
                    dctElementCounts[intElement] = intCurrentValue - 1;
                }
            }


            return intMissingElement;
        }

    }
}
