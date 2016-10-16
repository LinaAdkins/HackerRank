using System;
using System.Collections.Generic;

/// <summary>
/// For Happy Ladybugs challenge for Week of Code 24 Challenge 2
/// PASSED
/// URL: https://www.hackerrank.com/contests/w24/challenges/happy-ladybugs
/// Desc : Instead of recursively iterating or linearly sorting and then verifying I opted to use imposed constraints on the system to shortcut the solver.
/// I wish I hadn't gotten deathly ill at the beginning of this week of code. :-( Ah well!
/// </summary>
class Solution
{
    static void Main(String[] args)
    {
        int Q = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < Q; a0++)
        {
            // Iterate through our game strings
            int n = Convert.ToInt32(Console.ReadLine());
            string b = Console.ReadLine();

            // Solve this game and handle the result
            bool result = SolveGame(b);
            if(result){
                Console.WriteLine("YES");
            } else {
                Console.WriteLine("NO");
            }

        }
    }

    /// <summary>
    /// Solve an individual game by getting its board string. Returns true if all ladybugs are happy, false if they are not.
    /// </summary>
    static bool SolveGame(string game)
    {
        // Holds our ladybug type and count
        Dictionary<char, int> pieces = new Dictionary<char, int>();

        // Tally up the counts for our pieces
        for(int i=0; i < game.Length; i++)
        {
            if (pieces.ContainsKey(game[i]))
            {
                pieces[game[i]] += 1;
            }
            else
            {
                pieces.Add(game[i], 1);
            }
        }

        int value = 0;
        pieces.TryGetValue('_', out value);

        // If the ladybugs can't move, then verify the board as is
        if(value == 0)
        {
            return CheckHappy(game);
        }
        else // Ladybugs can move, fail if there is only one ladybug of a given type.
        {
            foreach( KeyValuePair<char,int> entry in pieces)
            {
                if(entry.Key != '_' && entry.Value == 1)
                {
                    return false;
                }
            }

            // RETURNS: We didn't fail so return true!
            return true;
        }

    }

    /// <summary>
    /// CHeck the game string to see if all ladybugs are next to another ladybug of the same type.
    /// </summary>
    static bool CheckHappy(string game)
    {
        for(int i=0; i < game.Length; i++)
        {
            char current = '-', frontof = '-' , behind = '-';
            current = game[i];
            if (i-1 >= 0) { frontof = game[i - 1]; }
            if(i+1 < game.Length) { behind = game[i + 1]; }
            if( current != frontof && current != behind)
            {
                return false;
            }
        }
        return true;
    }
}
