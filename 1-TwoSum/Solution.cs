using System;
using System.Collections.Generic;

namespace TwoSum
{
    public class Solution
    {
        private readonly Dictionary<int, int> _dict = new();

        public int[] TwoSum(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (_dict.TryGetValue(target - nums[i], out var index))
                    return new[] { index, i };

                _dict.Add(nums[i], i);
            }
            throw new ArgumentException("No solution.");
        }
    }
}
