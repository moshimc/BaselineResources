using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselineResources
{
    class BinarySearch
    {
        private static void Main(string[] args)
        {
            bool blnElementFound = false;
            int intElementToFind = 3;
            int[] aintSortedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            blnElementFound = BinarySearch_Recursive(aintSortedArray, intElementToFind, 0, aintSortedArray.Length);
            Console.WriteLine("Element '" + intElementToFind.ToString() + "': " + blnElementFound.ToString());
            Console.ReadLine();
        }


        // --------------------------------------------------------------------------------
        // Name: BinarySearch_NonRecursive
        // Purpose: Searching method that spits up our object to search by first examining 
        //          the middle item and splitting the object to search accordingly
        //
        //          In this example we are scooching either our 
        //          left indicator until we reach the element or the starting index 
        //          or our 
        //          right indicator until we reach the element or the last index
        //
        // --------------------------------------------------------------------------------
        private static bool BinarySearch_NonRecursive(int[] aintArrayToSearch, int intElementToFind)
        {
            bool blnFound = false;
            int intStart = 0;
            int intStop = aintArrayToSearch.Length - 1;
            int intMiddleItem = 0;
            int intMiddleIndex = 0;

            // We keep moving our midpoint until we reach our "perimeter" or we find 
            // the element
            while (intStart <= intStop && blnFound == false)
            {
                intMiddleIndex = (intStart + intStop) / 2;
                intMiddleItem = aintArrayToSearch[intMiddleIndex];

                if (intElementToFind == intMiddleItem)
                {
                    blnFound = true;
                }
                else
                {
                    // Is our element to the left of our midpoint?
                    if (intElementToFind < intMiddleItem)
                    {
                        // Yes, move our endpoint to the LEFT
                        intStop = intMiddleIndex - 1;
                    }
                    else
                    {
                        // No, move our endpoint to the RIGHT
                        intStart = intMiddleIndex + 1;
                    }
                }
            }

            return blnFound;
        }


        // --------------------------------------------------------------------------------
        // Name: BinarySearch_Recursive
        // Purpose: Searching method that spits up our object to search
        //          by first examining the middle item and splitting
        //          the object to search accordingly
        //          ** WITH RECURSION OH YAA **
        // --------------------------------------------------------------------------------
        private static bool BinarySearch_Recursive(int[] aintArrayToSearch, int intElementToFind, int intStart = 0, int intStop = 0)
        {
            bool blnFound = false;
            int intMidpoint = 0;


            // Anything to search?
            if (intStart <= intStop)
            {
                intMidpoint = (intStart + intStop) / 2;

                if (intElementToFind == aintArrayToSearch[intMidpoint])
                {
                    blnFound = true;
                }
                else if (intElementToFind < aintArrayToSearch[intMidpoint])
                {
                    blnFound = BinarySearch_Recursive(aintArrayToSearch, intElementToFind, intStart, intMidpoint - 1);
                }
                else if (intElementToFind > aintArrayToSearch[intMidpoint])
                {
                    blnFound = BinarySearch_Recursive(aintArrayToSearch, intElementToFind, intMidpoint + 1, intStop);
                }
            }

            return blnFound;
        }
    }
}
