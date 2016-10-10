using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {

        int numQueries = Convert.ToInt32(Console.ReadLine());
        Stack<int> stack = new Stack<int>();

        /// While we do keep our stack of values for useful reasons, we cache the latest large value if we can
        int maxValue = 0;
        int maxValueDepth = 0;
        bool maxValueLost = false;

        // Cycle through queries
        for (int i = 0; i < numQueries; i++)
        {
            string query = Console.ReadLine();
            string[] queryParts = query.Split(' ');
            int queryType = Convert.ToInt32(queryParts[0]);


            switch (queryType)
            {
                case 1: // PUSH
                    int pushedValue = Convert.ToInt32(queryParts[1]);

                    // New value is bigger, make it king!
                    if (pushedValue > maxValue)
                    {
                        maxValue = pushedValue;
                        maxValueDepth = 0;
                        maxValueLost = false;
                    }
                    else
                    {
                        maxValueDepth++;
                    }


                    stack.Push(pushedValue);
                    break;
                case 2: // POP

                    // If we've popped too far then we've lost our cache
                    if (maxValueDepth <= 0 && maxValueLost == false)
                    {
                        maxValueLost = true;
                    }
                    else
                    {
                        maxValueDepth--;
                    }

                    stack.Pop();
                    break;
                case 3: // PRINT

                    // If we don't have a ached value, do expensive lookup, else use cached value
                    if (maxValueLost)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else
                    {
                        Console.WriteLine(maxValue);
                    }

                    break;
            }


        }
    }
}