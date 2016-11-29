/// ------------------------------------------------------------
/// Name: MergeSort
/// Author: Matthew Collard
/// Purpose: Given two strings, check to see if they are anagrams
/// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselineResources
{
    public class AnagramCheck
    {
        public static void Main(string[] args)
        {
            bool blnAnagram = false;
            Console.WriteLine("Hello World!");
            blnAnagram = Anagram("hello world", "world hello");
            Console.WriteLine(blnAnagram.ToString());
            Console.ReadLine();
        }

        private static bool Anagram(String string1, String string2)
        {
            bool blnAnagram = true;
            char[] achrSortedOne = null;
            char[] achrSortedTwo = null;

            if (string1.Length != string2.Length)
            {
                blnAnagram = false;
            }

            if (blnAnagram != false)
            {
                // Sort each string            
                achrSortedOne = string1.ToArray();
                achrSortedTwo = string2.ToArray();
                Array.Sort(achrSortedOne);
                Array.Sort(achrSortedTwo);

                // 
                for (int i = 0; i < string1.Length; i++)
                {
                    if (achrSortedOne[i] != achrSortedTwo[i])
                    {
                        Console.WriteLine(achrSortedOne[i] + ", " + achrSortedTwo[i]);
                        blnAnagram = false;
                    }
                }
            }

            return blnAnagram;
        }
    }
}
