using System;

/// <summary>
/// HackerRank - 30 Days of Code - Binary Numbers
/// 
/// URL: https://www.hackerrank.com/challenges/30-binary-numbers
/// </summary>
class Solution
{
    static void Main(String[] args)
    {

        int n = Convert.ToInt32(Console.ReadLine());

        int streak = 0;
        int largest_streak = 0;

        // Solve by dividing 
        while (true)
        {

            // If we're currently on a '1'/Odd number, add to streak , else reset streak and watch largest
            if (n % 2 != 0)
            {
                streak++;
            }
            else
            {
                if (streak > largest_streak) { largest_streak = streak; }
                streak = 0;
            }

            // BREAK: We've done our last divison.
            if (n == 1)
            {
                if (streak > largest_streak) { largest_streak = streak; }
                break;
            }

            n /= 2;

        }

        Console.WriteLine(largest_streak);

    }
}