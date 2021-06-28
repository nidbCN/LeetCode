using System;

namespace ReverseInteger
{
    public class Solution2
    {
        private readonly int[] _digits = new int[10];

        private readonly int[] _powTable = new[] {
            10,100,1000,10000,100000,1000000,10000000,100000000,1000000000
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
            var isNegative = x < 0;
            x = Math.Abs(x);

            var i = 0;
            while (x > 0)
            {
                _digits[10 - ++i] = (x % 10);
                x /= 10;
            }

            var ret = 0;

            if (i == 10)
            {
                while (i >= 0)
                {
                    var digit = _digits[10 - i];

                    // check overflow
                    if (isNegative)
                    {
                        if (digit > _negOverflowTable[i])
                            return 0;
                    }
                    else if (digit > _posOverflowTable[i])
                        return 0;

                    ret += (int)Math.Pow(10, i--) * digit;
                }

            }
            else
            {
                for (var j = 9; i > 0; j--)
                {
                    var digit = _digits[10 - i];

                    ret += (int)Math.Pow(10, --i) * digit;
                }
            }

            if (isNegative) return -ret;
            return ret;
        }
    }
}
