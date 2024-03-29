﻿using System.Collections.Generic;

namespace ClimbingStairs
{
    class Solution2
    {
        public int ClimbStairs(int n)
        {
            var table = new int[n - 1]; // 创建表

            if (n <= 3) return n;       // i <= 3时，返回相应结果即可

            // 初始化表
            table[1] = 2;
            table[2] = 3;

            // 计算前两次的值并存储
            for (int i = 3; i < n - 1; i++)
            {
                table[i] = table[i - 1] + table[i - 2];
            }

            return table[n - 2] + table[n - 3];
        }
    }
}
