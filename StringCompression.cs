using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselineResources
{
    class StringCompression
    {
        private static void Main(string[] args)
        {
            string strTestString = "AAAAABBBBCCCC";
            string strTestString2 = "AAABCCDDDDD";
            string strTestString3 = "AaaaBBbb";
            Console.WriteLine(CompressString_UsingDictionary(strTestString3));
            Console.ReadLine();
        }


        // ------------------------------------------------------------
        // Name: CompressString
        // Purpose: Compress letters of a string 
        //          AAABBCCCC => A3B2C4
        //          AaaaBBbb => A1a3B2b2
        // ------------------------------------------------------------
        private static string CompressString(string strStringToCompress)
        {
            string strCompressedString = "";
            int intLetterCount = 1;
            int intStringLength = 0;
            int intIndex = 0;

            // Trim for good measure
            strStringToCompress.Trim();

            intStringLength = strStringToCompress.Length;

            // If no length we skip to bottom
            // If length = 1 just return the first char + "1"
            if (intStringLength == 1)
            {
                strCompressedString = strStringToCompress + "1";
            }
            // Otherwise...
            else if (intStringLength > 1)
            {
                for (intIndex = 1; intIndex < intStringLength; intIndex++)
                {
                    // Same letter as previously?
                    if (strStringToCompress[intIndex].Equals(strStringToCompress[intIndex - 1]))
                    {
                        intLetterCount += 1;
                    }
                    else
                    {
                        strCompressedString = strCompressedString + strStringToCompress[intIndex - 1] + intLetterCount.ToString();
                        intLetterCount = 1;
                    }
                }
            }

            // When we reach the end we need to add what's remaining in our "buffer"
            strCompressedString = strCompressedString + strStringToCompress[intIndex - 1] + intLetterCount.ToString();

            return strCompressedString;
        }


        // ------------------------------------------------------------
        // Name: CompressString_UsingDictionary
        // Purpose: Compress letters of a string and use a dictionary
        //          AAABBCCCC => A3B2C4
        //          AaaaBBbb => A1a3B2b2
        // ------------------------------------------------------------
        private static string CompressString_UsingDictionary(string strStringToCompress)
        {
            string strCompressedString = "";
            int intLetterCount = 0;
            int intStringLength = 0;
            int intIndex = 0;
            Dictionary<char, int> dctLettersFound = new Dictionary<char, int>();

            // Trim for good measure
            strStringToCompress.Trim();

            intStringLength = strStringToCompress.Length;

            // If no length we skip to bottom
            // If length = 1 just return the first char + "1"
            if (intStringLength == 1)
            {
                strCompressedString = strStringToCompress + "1";
            }
            // Otherwise...
            else if (intStringLength > 1)
            {
                // For each letter...
                for (intIndex = 0; intIndex < intStringLength; intIndex++)
                {
                    // Grab the current count of said letter and update our dictionary
                    dctLettersFound.TryGetValue(strStringToCompress[intIndex], out intLetterCount);
                    dctLettersFound[strStringToCompress[intIndex]] = intLetterCount + 1;
                }
            }

            // Loop through our dictionary and format the string
            foreach (KeyValuePair<char, int> kvpLettersAndCounts in dctLettersFound)
            {
                strCompressedString += kvpLettersAndCounts.Key + kvpLettersAndCounts.Value.ToString();
            }

            return strCompressedString;
        }
    }
}
