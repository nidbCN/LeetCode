using System;

namespace RomanToInteger
{
    class Solution2
    {
        public int RomanToInt(string s)
        {
            var strSpan = s.AsSpan();

            var result = 0;
            var lastNum = GetRomanCharValue(strSpan[0]);

            foreach(var ch in  strSpan[1..])
            {
                var num = GetRomanCharValue(ch);

                if (lastNum < num)
                {
                    result -= lastNum;
                }
                else
                {
                    result += lastNum;
                }

                lastNum = num;
            }

            return result + lastNum;
        }

        private static int GetRomanCharValue(char ch)
            => ch switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentException($"Unknow roman char {ch}"),
            };
    }
}
