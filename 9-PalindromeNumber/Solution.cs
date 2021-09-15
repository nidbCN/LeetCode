namespace PalindromeNumber
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            var result = 0;

            for (var num = x; num != 0; num /= 10)
                result = result * 10 + num % 10;

            return result == x;
        }
    }
}
