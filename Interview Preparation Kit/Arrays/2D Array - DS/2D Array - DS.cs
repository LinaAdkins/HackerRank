using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    /// <summary>
    /// Each hourglass can have 7 elements, and the lowest value per element is -9.
    /// </summary>
    public const int lowestPossibleSum = -9 * 7;

    /// <summary>
    /// Padding for top/left of hourglass center.
    /// </summary>
    public const int lowerBound = 1;

    /// <summary>
    /// Padding for bottom/right of hourglass center.
    /// </summary>
    public const int upperBound = 5;

    // <summary>
    // Sum all hourglasses in array and find highest value.
    // </summary>
    static int hourglassSum(int[][] arr)
    {
        int highestSum = lowestPossibleSum; // We start at lowest possible sum so our comparator works

        for (int y = lowerBound; y < upperBound; y++)
        {
            for (int x = lowerBound; x < upperBound; x++)
            {
                // The calculation is laid out in the shape of the hourglass/I visually for easy troubleshooting
                int currentSum = arr[y - 1][x - 1] + arr[y - 1][x] + arr[y - 1][x + 1] +
                                                  arr[y][x] +
                              arr[y + 1][x - 1] + arr[y + 1][x] + arr[y + 1][x + 1];

                if (currentSum > highestSum)
                {
                    highestSum = currentSum;
                }
            }

        }

        return highestSum;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++)
        {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
