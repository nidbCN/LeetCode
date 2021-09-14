using System;
using System.Collections.Generic;

namespace ClimbingStairs
{
    public class Solution
    {
        public int ClimbStairs(int n)
        {
            var result = IsEven(n) ? 2 : 1;  // 奇数偶数预先加值
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
        private static bool IsEven(int num)
            => (num & 1) == 0;

        /// <summary>
        /// 是否为奇数
        /// </summary>
        /// <param name="num">数字</param>
        /// <returns>是否为奇数</returns>
        private static bool IsEven(long num)
            => (num & 1) == 0;

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
        {
            // 分子值
            long moleculeValue = 1;
            long denominatorValue;

            // 分子的集合
            var moleculesList = new HashSet<int>();
            for (var i = 1; i <= n; i++)
            {
                moleculesList.Add(i);
            }

            // 分母的集合
            var denominatorsList = new LinkedList<int>();

            // 选取较少的一项进行计算
            int denominatorCnt;

            var o = n - m;
            // 分母值
            if (o > m)
            {
                denominatorValue = Factorial(m);
                denominatorCnt = o;
            }
            else
            {
                denominatorValue = Factorial(o);
                denominatorCnt = m;
            }

            // 进行分子分母相消
            for (var i = 1; i <= denominatorCnt; i++)
            {
                if (moleculesList.Contains(i))
                {
                    moleculesList.Remove(i);
                }
                else
                {
                    denominatorsList.AddLast(i);
                }
            }

            // 计算分母值
            foreach (var val in denominatorsList)
            {
                denominatorValue *= val;
            }
            // 计算分子值
            foreach (var val in moleculesList)
            {
                if (IsEven(val) && IsEven(denominatorValue))
                {
                    denominatorValue >>= 1;
                    moleculeValue *= (val >> 1);
                }
                else
                {
                    moleculeValue *= val;
                }

            }

            return (int)(moleculeValue / denominatorValue);
        }
    }
}
