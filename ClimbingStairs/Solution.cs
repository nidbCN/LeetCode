using System;

namespace ClimbingStairs
{
    public class Solution
    {
        public static void Main()
        {
            var t = new Solution();
            Console.WriteLine(t.ClimbStairs(35));
        }

        public int ClimbStairs(int n)
        {
            var result = IsOdd(n) ? 1 : 2;  // 奇数偶数预先加值
            var cnt = (n - 1) >> 1;         // 循环组合次数

            for (var i = 1; i <= cnt; i++)
                result += Combine(i, n - i);    // 计算组合值

            return result;
        }

        /// <summary>
        /// 是否为奇数
        /// </summary>
        /// <param name="num">数字</param>
        /// <returns>是否为奇数</returns>
        private bool IsOdd(int num)
            => (num & 1) == 1;

        /// <summary>
        /// 计算阶乘
        /// </summary>
        /// <param name="x">阶数</param>
        /// <returns>x!</returns>
        private long Factorial(long x)
                => x <= 1 ? 1 : x * Factorial(x - 1);

        /// <summary>
        /// 组合
        /// </summary>
        /// <param name="m">取出元素的个数</param>
        /// <param name="n">元素总个数</param>
        /// <returns></returns>
        private int Combine(int m, int n)
            => (int)(Permute(m, n) / Factorial(m));

        /// <summary>
        /// 排列
        /// </summary>
        /// <param name="m">取出元素的个数</param>
        /// <param name="n">元素总个数</param>
        /// <returns></returns>
        private long Permute(int m, int n)
            => Factorial(n) / Factorial(n - m);
    }
}
