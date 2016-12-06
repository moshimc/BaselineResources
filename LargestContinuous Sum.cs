using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselineResources
{
    class LargestContinuous_Sum
    {
        private static void Main(string[] args)
        {
            int[] aintArrayToCheck = new int[] { 1, 2, -1, 3, 4, 10, 10, -10, -1 };
            int[] aintArrayToCheck2 = new int[] { -1, 1 };
            int intLargestSum = 0;
            intLargestSum = FindTheLargestContinuousSum(aintArrayToCheck2);
            Console.WriteLine("The Largest Continuous Sum = " + intLargestSum.ToString());
            Console.ReadLine();
        }


        // ------------------------------------------------------------
        // Name: FindTheLargestContinuousSum
        // Purpose: Loop through both sorted arrays at the same time to
        //          determine the missing element
        // ------------------------------------------------------------
        private static int FindTheLargestContinuousSum(int[] aintArray)
        {
            int intLargestSum = 0;
            int intCurrentSum = 0;

            // Any items to summate?
            if (aintArray.Length > 0)
            {
                // Set our max sum as the first element
                intLargestSum = aintArray[0];
                intCurrentSum = aintArray[0];
                
                // For every element in the array
                for (int intIndex = 1; intIndex < aintArray.Length; intIndex += 1)
                {
                    // Set the current sum as the higher of the two
                    // e.g. 10+12/10 || 10-8/-8
                    intCurrentSum = Math.Max(intCurrentSum + aintArray[intIndex], aintArray[intIndex]);
                    //Console.WriteLine("CurrentSum: " + intCurrentSum.ToString());

                    // Set the max as the higher between the current sum and the current max
                    intLargestSum = Math.Max(intCurrentSum, intLargestSum);
                    //Console.WriteLine("LargestSum: " + intLargestSum.ToString());
                }
            }

            return intLargestSum;
        }
    }
}
