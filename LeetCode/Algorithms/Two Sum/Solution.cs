public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        // Key is number,  value is indice
        var complements = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (complements.ContainsKey(complement))
            {
                return new int[] { complements[complement], i };
            }

            complements[nums[i]] = i;
        }

        throw new Exception("No solution!");
    }
}