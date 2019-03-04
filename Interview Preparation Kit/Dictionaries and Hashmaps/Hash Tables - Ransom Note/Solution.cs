using System.Collections.Generic;
using System;

class Solution
{

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note)
    {

        // Set up a dictionary that uses word as key, number of occurences as value.
        var magwords = new Dictionary<string, int>();
        foreach (var word in magazine)
        {
            if (magwords.ContainsKey(word))
            {
                magwords[word] += 1;
                continue;
            }
            magwords.Add(word, 1);
        }

        // Test each word in the note and see if we have it in the magazine
        // We also check that we have enough of said word left and "use" words up.
        var answer = "Yes";
        foreach (var word in note)
        {
            if (!magwords.ContainsKey(word) || magwords[word] < 1)
            {
                answer = "No";
                break;
            }

            magwords[word] -= 1;
        }

        Console.WriteLine(answer);
    }

    // HackerRank Boilerplate
    static void Main(string[] args)
    {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = Console.ReadLine().Split(' ');

        string[] note = Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}
