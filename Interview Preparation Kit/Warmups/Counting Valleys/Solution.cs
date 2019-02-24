using System.IO;
using System;

class Solution
{

    static int countingValleys(int n, string s)
    {

        int curr_height, prev_height, valleys_traversed;
        curr_height = valleys_traversed = prev_height = 0;

        for (int i = 0; i < n; i++)
        {
            prev_height = curr_height;

            curr_height += s[i] == 'U' ? 1 : -1;

            // Since mountains can never have a valley in them per definition, we can just count every time we return from below sea level to sea level.
            if (prev_height < 0 && curr_height == 0)
            {
                valleys_traversed++;
            }
        }

        return valleys_traversed;

    }

    // HackerRank Boilerplate
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        int result = countingValleys(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}