using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselineResources
{
    class SentenceReversal
    {
        private static void Main(string[] args)
        {
            string strSentence = "Hi John,  are you ready to go?";
            string strSentence2 = "   Hello John    how are you   ";
            Console.WriteLine(ReverseSentence(strSentence2));
            Console.ReadLine();
        }


        // ------------------------------------------------------------
        // Name: ReverseSentence
        // Purpose: Reverse the words in a sentence (including punctuation)
        // ------------------------------------------------------------
        private static string ReverseSentence(string strSentenceToReverse)
        {
            string strReversedSentence = "";
            char chrSpace = ' ';
            int intStartIndex = 0;
            List<string> lstrWords = new List<string>();

            for (int intIndex = 0; intIndex < strSentenceToReverse.Length; intIndex++)
            {
                // Did we find the starting position of a word?
                if (strSentenceToReverse[intIndex].Equals(chrSpace) == false)
                {
                    // Yes, store the index
                    intStartIndex = intIndex;

                    // Now that we know where to start, loop until we reach the end or a space
                    while (intIndex < strSentenceToReverse.Length && strSentenceToReverse[intIndex].Equals(chrSpace) == false)
                    {
                        intIndex += 1;
                    }

                    // Now that we have our start and finish position, add our word to the list
                    lstrWords.Add(strSentenceToReverse.Substring(intStartIndex, intIndex - intStartIndex));
                }
            }

            // Now we need to reverse the words!
            lstrWords.Reverse();
            foreach (string word in lstrWords)
            {
                strReversedSentence += word + " ";
            }

            // Trim for trailing spaces
            strReversedSentence.Trim();

            return strReversedSentence;
        }
    }
}
