using System;

namespace RomanToInteger
{
    public class Solution
    {
        private static bool MayHasNext(char ch)
            => (ch) switch
            {
                'I' => true,
                'X' => true,
                'C' => true,
                _ => false,
            };

        public static bool TryParse(char ch, out int num)
            => TryParse(ch.ToString(), out num);

        public static bool TryParse(char ch1, char ch2, out int num)
            => TryParse($"{ch1}{ch2}", out num);

        public static bool TryParse(string s, out int num)
            => (num = s switch
            {
                "I" => 1,
                "V" => 5,
                "X" => 10,
                "L" => 50,
                "C" => 100,
                "D" => 500,
                "M" => 1000,
                "IV" => 4,
                "IX" => 9,
                "XL" => 40,
                "XC" => 90,
                "CD" => 400,
                "CM" => 900,
                _ => -1,
            }) != -1;

        public int RomanToInt(string s)
        {
            if (s is null) throw new ArgumentNullException(nameof(s));
            if (s == string.Empty) return 0;

            var result = 0;

            var i = 0;
            while (i < s.Length)
            {
                var ch = s[i];
                if (MayHasNext(ch) && i < s.Length - 1)
                {
                    if (TryParse(ch, s[i + 1], out var numOfTwo))
                    {
                        result += numOfTwo;
                        i += 2;
                        continue;
                    }
                }

                if (TryParse(ch, out var num))
                    result += num;

                i++;
            }

            return result;
        }
    }
}
