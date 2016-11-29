using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselineResources
{
    class PairSum
    {
        public static void Main(string[] args)
        {
            Dictionary<int, int> dctPairs = new Dictionary<int, int>();
            //int[] aintArrayToSearch = new int[] { 1, 3, 2, 2 };
            //int intSumToFind = 4;
            int[] aintArrayToSearch = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5, 5, 13, 14, 11, 13, -1 };
            int intSumToFind = 10;
            dctPairs = FindPairSum(aintArrayToSearch, intSumToFind);
            Console.WriteLine(dctPairs.ToString());
            Console.ReadLine();
        }

        private static Dictionary<int, int> FindPairSum(int[] aintArray, int intTargetSum)
        {
            Dictionary<int, int> dctPairs = new Dictionary<int, int>();
            int intTargetValue = 0;

            try
            {
                // Anything to check?
                if (aintArray.Length >= 2)
                {
                    // Yes

                    // Tracking 
                    List<int> alintSeenValue = new List<int>();

                    // For each number in our array...
                    foreach(int intValue in aintArray)
                    {
                        intTargetValue = intTargetSum - intValue;

                        // Have we seen our target value yet?
                        if (alintSeenValue.Contains(intTargetValue) == false)
                        {
                            // No, add it to our list of seen values
                            alintSeenValue.Add(intValue);
                        }
                        else
                        {
                            // Yes, add our pair
                            dctPairs.Add(Math.Min(intValue, intTargetValue), Math.Max(intValue, intTargetValue));
                        }
                    }
                }
            }
            catch (Exception excError)
            {
                Console.WriteLine("Error: " + excError.ToString());
            }

            return dctPairs;
        }
    }


}
