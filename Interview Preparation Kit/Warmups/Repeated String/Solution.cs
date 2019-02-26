using System.IO;
using System.Linq;
using System;

class Solution
{

    // Counts all occurences of 'a' in a repeated string 's'
    static long repeatedString(string s, long n)
    {

        // Get a count of all full cycles first
        long count = s.Count(f => f == 'a');
        var full_cycles = n / s.Length;
        int leftover = (int)(n % s.Length);
        var answer = full_cycles * count;

        // Get the remainder and add it to answer
        string newstring = "";
        if (leftover > 0)
        {
            newstring = s.Substring(0, leftover);
        }

        answer += newstring.Count(f => f == 'a');

        return answer;
    }

    // HackerRank Boilerplate
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine());

        long result = repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
