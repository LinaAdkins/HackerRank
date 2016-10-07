using System;
using System.Collections.Generic;
using System.IO;

public class Solution
{
    static void insertionSort(int[] ar)
    {
        // RETURN: Array is already sorted as it has 1 or less elements!
        if (ar.Length <= 1) { return; }


        // Iterate up through our array - we start at i = 1 since first element cannot move left
        for (int i = 1; i < ar.Length; i++)
        {

            // Iterate down through all values to the left of val to sort
            for (int j = i - 1; j >= 0; j--)
            {
                // Shift value to left if we are too high!
                if (ar[j + 1] < ar[j])
                {
                    int valToSort = ar[j + 1];
                    ar[j + 1] = ar[j];
                    ar[j] = valToSort;
                }
                // Value needs to go no further left, break and go up
                else
                {
                    break;
                }
            }

            PrintArray(ar);

        }

    }

    static void PrintArray(int[] ar)
    {
        string output = "";
        foreach (int i in ar)
        {
            output += i.ToString() + " ";
        }

        Console.WriteLine(output.Trim());
    }



    static void Main(String[] args)
    {

        int _ar_size;
        _ar_size = Convert.ToInt32(Console.ReadLine());
        int[] _ar = new int[_ar_size];
        String elements = Console.ReadLine();
        String[] split_elements = elements.Split(' ');
        for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
        {
            _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
        }

        insertionSort(_ar);
    }
}
