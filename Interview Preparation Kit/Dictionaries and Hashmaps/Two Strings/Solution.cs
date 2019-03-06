using System.Collections.Generic;
using System;
using System.IO;

class Solution {

    // Check to see if one string contains any substrings of the other.
    static string twoStrings(string s1, string s2) {

        HashSet<char> h1 = new HashSet<char>(s1);

        /* We could convert both to HashSets, but the resulting time 
complexity
         * would be the same and overlaps works with arrays, so this 
saves
         * us a bit of memory. */
        if(h1.Overlaps(s2)){
            return "YES";
        }

        return "NO";
    }

    // HackerRank Boilerplate
    static void Main(string[] args) {
        TextWriter textWriter = new 
StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), 
true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            string result = twoStrings(s1, s2);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
