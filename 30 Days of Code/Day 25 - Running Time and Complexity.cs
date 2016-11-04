using System;

/// <summary>
/// HackerRank - 30 Days of Code - Running Time and Complexity
/// 
/// URL: https://www.hackerrank.com/challenges/30-running-time-and-complexity
/// </summary>
class Solution
{
    // Entry point
    static void Main(String[] args)
    {
        // Number of cases, 1 <= T <= 20
        int t = Convert.ToInt32(Console.ReadLine());

        for (int a0 = 0; a0 < t; a0++)
        {
            // Number to find if prime, 1 <= n <= 10^9 , can be contained by int32
            int num = Convert.ToInt32(Console.ReadLine());
            if (CheckPrimality(num))
            {
                Console.WriteLine("Prime");
            }
            else
            {
                Console.WriteLine("Not prime");
            }
        }

        // Pause
        Console.ReadKey();
    }

    static bool CheckPrimality(Int32 num)
    {
        // Get some basic cases out of the way
        if (num == 1) { return false; }

        // We only need to check all multiples up to the square of the number. This lowers our time to O(sqrt(n))
        int numSquare = Convert.ToInt32(Math.Sqrt(num));

        // Iterate through 1-num*0.5 , going only up to sqrt(num)
        for (int i = 2; i <= numSquare; i++)
        {
            if (num % i == 0) { return false; }

        }
        return true;
    }
}
