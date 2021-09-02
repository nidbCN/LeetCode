using System;

namespace ReverseInteger
{
    public class Solution2
    {
        private readonly int[] _digits = new int[10];

        private readonly int[] _powTable = new[] {
            1,10,100,1000,10000,100000,1000000,10000000,100000000,1000000000
        };

        private readonly int[] _posOverflowTable = new int[]
        {
            2,1,4,7,4,8,3,6,4,7
        };

        private readonly int[] _negOverflowTable = new int[]
        {
            2,1,4,7,4,8,3,6,4,8
        };

        public int Reverse(int x)
        {
            if (x == 0) return 0;
            if (x == int.MinValue) return 0;

            var isNegative = x < 0;
            x = Math.Abs(x);

            var i = 0;
            while (x > 0)
            {
                _digits[10 - ++i] = (x % 10);
                x /= 10;
            }

            var length = i;
            var ret = 0;

            // no overflow
            for (var j = 9; i > 0; j--)
            {
                var digit = _digits[j];

                ret += _powTable[--i] * digit;
            }

            if (ret % 10 != _digits[10 - length]) return 0;

            if (isNegative) return -ret;
            return ret;
        }

        private void WriteArray(int[] arr)
        {
            Console.Write("[ ");
            foreach (var item in arr)
            {
                Console.Write($"{item}, ");
            }
            Console.Write("]");
        }
    }
}
