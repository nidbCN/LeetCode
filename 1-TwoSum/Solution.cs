using System;
using System.Collections.Generic;

namespace TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var otherNumber = target - nums[i];

                if (dict.TryGetValue(otherNumber, out var index))
                    return new int[2] { index, i };
            
                dict.Add(nums[i], i);
            }

            throw new ArgumentException("No solution.");
        }
    }
}
