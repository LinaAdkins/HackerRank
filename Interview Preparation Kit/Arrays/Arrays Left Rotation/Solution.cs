using System;
using System.IO;

class Solution
{

    // Rotleft using standard 'Juggling' to avoid swap in place issues with skipped values.
    static int[] rotLeft(int[] a, int d)
    {

        int s = a.Length;

        for (int i = 0; i < gcd(d, s); i++)
        {

            int temp = a[i];
            int j = i;

            while (true)
            {
                int k = j + d;

                // If our rotation will take us past 0 index, roll over
                if (k >= s)
                {
                    k = k - s;
                }

                // We've looped back around and are done with this set
                if (k == i)
                {
                    break;
                }

                // Move our values and increment to the next in the set.
                a[j] = a[k];
                j = k;
            }

            a[j] = temp; // carry last number
        }

        return a;
    }

    // Standard gcd algorithm
    static int gcd(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        if (a == 0)
            return b;
        else
            return a;

    }

    // HackerRank provided boilerplate
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;
        int[] result = rotLeft(a, d);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}