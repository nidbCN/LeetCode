using System;
using System.Collections.Generic;

namespace PalindromeNumber
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;

            var stack = new Stack<int>();

            while (x != 0)
            {
                var num = x % 10;

                if(!stack.TryPeek(out var top))
                {
                    if(top != num)
                    {

                    }
                }
                else
                {
                    return false;
                }

                x /= 10;
            }
        }
    }
}
