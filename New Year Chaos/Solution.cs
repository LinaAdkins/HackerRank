using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

class Solution
{

    // Given an array, we determine how many swaps ( max of two ) each position moved forward in the line. We go over the array until it is sorted, advancing larger numbers that are out of place.
    static void minimumBribes(int[] q)
    {

        int[] swaps = new int[q.Length]; // A map to keep count of how many bribes/swaps each position has had.
        bool sorted = false;
        int totalSwaps = 0;

        while (!sorted)
        {
            bool doneswapping = true;

            for (int i = 0; i < q.Length - 1; i++)
            {
                // If we've found a number out of place, let the loop know we aren't sorted and increment our counters.
                if (q[i] > q[i + 1])
                {
                    // RETURN: Another bribe/swap would increment us past our thresshold of 2
                    if (swaps[q[i] - 1] == 2) { Console.WriteLine("Too chaotic"); return; }

                    doneswapping = false;
                    swaps[q[i] - 1] += 1;
                    swap(q, i, i + 1);
                    totalSwaps++;
                }
            }
            // If we've gotten this far and the doneswapping flag isn't set, we know the array is sorted and we are done.
            if (doneswapping)
            {
                sorted = true;
            }
        }

        Console.WriteLine(totalSwaps);
    }

    static void swap(int[] arr, int a, int b)
    {
        var temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }

    // HackerRank Boilerplate
    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
            ;
            minimumBribes(q);
        }
    }
}