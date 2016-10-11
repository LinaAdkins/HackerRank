using System;

/// <summary>
/// For apples/oranges challenege for Week of Code 24 Challenge 1
/// PASSED
/// URL: https://www.hackerrank.com/contests/w24/challenges/apple-and-orange
/// </summary>
class Solution {

    static void Main(String[] args) {
        string[] tokens_s = Console.ReadLine().Split(' ');
        int s = Convert.ToInt32(tokens_s[0]);
        int t = Convert.ToInt32(tokens_s[1]);
        string[] tokens_a = Console.ReadLine().Split(' ');
        int a = Convert.ToInt32(tokens_a[0]);
        int b = Convert.ToInt32(tokens_a[1]);
        string[] tokens_m = Console.ReadLine().Split(' ');
        int m = Convert.ToInt32(tokens_m[0]);
        int n = Convert.ToInt32(tokens_m[1]);
        string[] apple_temp = Console.ReadLine().Split(' ');
        int[] apple = Array.ConvertAll(apple_temp,Int32.Parse);
        string[] orange_temp = Console.ReadLine().Split(' ');
        int[] orange = Array.ConvertAll(orange_temp,Int32.Parse);
        
        
        // Distance required to travel for each tree to hit house
        int appleDistanceMin = s - a; // Positive distance
        int appleDistanceMax = t - a; // Overshoot distance
        int orangeDistanceMax = t - b; // Negative distance
        int orangeDistanceMin = s - b; // Overshoot distance

        // Results to print
        int applesHit = 0, orangesHit = 0;

        // Calc apple hits
        for (int i = 0; i < m; i++)
        {
            if (apple[i] >= appleDistanceMin && apple[i] <= appleDistanceMax )
            {
                applesHit++;
            }
        }

        // Calc orange hits
        for (int j = 0; j < n; j++)
        {
            if (orange[j] <= orangeDistanceMax && orange[j] >= orangeDistanceMin )
            {
                orangesHit++;
            }
        }

        // Required output
        Console.WriteLine(applesHit);
        Console.WriteLine(orangesHit);
    }
}