using System;

/// <summary>
/// HackerRank Contest - Project Euler #1: Multiples of 3 and 5
/// PASSED
/// URL: https://www.hackerrank.com/contests/projecteuler/challenges/euler001/submissions/code/7472532
/// </summary>
class Solution
{
    // Entry point
    static void Main(String[] args)
    {
        // Number of cases, can be 10^5 and always positive
        int t = Convert.ToInt32(Console.ReadLine());

        for (int a0 = 0; a0 < t; a0++)
        {
            // Number to get multiples sum of, can be 10^9 and always positive
            int n = Convert.ToInt32(Console.ReadLine());

            ulong answer = SummateMultiples((ulong)n, 3) + SummateMultiples((ulong)n, 5) - SummateMultiples((ulong)n, 15);

            Console.WriteLine(answer);
        }

        Console.ReadKey();
    }

    /// <summary>
    /// Find and sum all multiples less than a given number with a given multiple.
    /// </summary>
    static ulong SummateMultiples(ulong number, ulong multiple)
    {
        ulong max = (number - 1) / multiple;
        ulong sum = 0;

        // If we iterate through the numbers we get horrid time, so we use the sigma identity instead
        sum = (multiple * max * (max + 1)) / 2;

        return sum;
    }
}
