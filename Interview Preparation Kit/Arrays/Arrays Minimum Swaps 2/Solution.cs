using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

class Solution
{
    /// Returns the number of swaps an array must make to sort it.
    static int minimumSwaps(int[] arr)
    {

        // Move our array into a key value pair so we can sort it, but still have the index data.
        var arrSorted = new List<KeyValuePair<int, int>>(arr.Length);
        for (int i = 0; i < arr.Length; i++)
        {
            arrSorted.Add(new KeyValuePair<int, int>(arr[i], i));
        }

        // Sort by the key
        arrSorted.Sort((x, y) => x.Key.CompareTo(y.Key));

        // Set up tracking for visited nodes
        List<bool> visited = Enumerable.Repeat(false, arr.Length).ToList();

        int answer = 0;

        // Iterate through every element and find graph connections for swaps, then count them.
        for (int i = 0; i < arr.Length; i++)
        {

            // Element is already visited or already sorted!
            if (visited[i] || arrSorted[i].Value == i) { continue; }

            int j = i;
            int swaps = 0;

            // Visit nodes, tracking down each numbers' index until we find out the number of moves required!
            while (!visited[j])
            {
                visited[j] = true;

                j = arrSorted[j].Value;
                swaps++;
            }

            answer += swaps - 1;
        }
        return answer;
    }

    // HackerRank Boilerplate
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = minimumSwaps(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}