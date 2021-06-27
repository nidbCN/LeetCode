using System;
using System.Text;

namespace ReverseInteger
{
    public class Solution
    {
        public int Reverse(int x)
        {
            string resultStr = null;

            var inputStr = x.ToString();
            var inputSpan = inputStr.AsSpan();

            var outputArr = new char[inputStr.Length + 1];
            var outputSpan = new Span<char>(outputArr);

            var i = inputStr.Length - 1;
            var j = 1;

            while (i > 0)
            {
                outputSpan[j++] = inputSpan[i--];
            }

            if (inputSpan[0] == '-')
            {
                outputSpan[0] = '-';
                resultStr = outputSpan.ToString();
            }
            else
            {
                outputSpan[j] = inputSpan[0];
                resultStr = outputSpan[1..].ToString();
            }

            return int.TryParse(resultStr, out var result)
                ? result
                : 0;
        }
    }
}
