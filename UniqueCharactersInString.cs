using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselineResources
{
    class UniqueCharactersInString
    {
        private static void Main(string[] args)
        {
            string strStringToTest = "";
            string strStringToTest2 = "gobo";
            string strStringToTest3 = "abcdefg";
            Console.WriteLine(AreAllCharactersUnique(strStringToTest3).ToString());
            Console.ReadLine();
        }

        private static bool AreAllCharactersUnique(string strStringToCheck)
        {
            bool blnAllUnique = true;
            List<char> lchrCharacters = new List<char>();
            int intIndex = 0;
            int intStringLength = strStringToCheck.Length;

            // Anything to check?
            if (intStringLength > 0)
            {
                // Yes, loop until we reach the end or a non-unique char
                while (blnAllUnique && intIndex < intStringLength)
                {
                    // Have we seen our char yet?
                    if (lchrCharacters.Contains(strStringToCheck[intIndex]) == false)
                    {
                        // No, add it
                        lchrCharacters.Add(strStringToCheck[intIndex]);
                    }
                    else
                    {
                        // Yes, shows over--wrap it up!
                        blnAllUnique = false;
                    }

                    // Counter
                    intIndex += 1;
                }
            }

            return blnAllUnique;
        }
    }
}
