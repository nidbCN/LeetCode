using System.Collections.Generic;

namespace PacificAtlanticWaterFlow
{
    public class Solution
    {
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            var res = new List<IList<int>>();
            var m = heights.Length;
            var n = heights[0].Length;

            //记录坐标地是否到达太平洋、大西洋
            var canReachP = new bool[m, n];
            var canReachX = new bool[m, n];
            //上下左右出发，深度优先搜索
            for (int i = 0; i < m; i++)
            {
                DepthFirstSearch(heights, canReachP, i, 0);
                DepthFirstSearch(heights, canReachX, i, n - 1);
            }
            for (int j = 0; j < n; j++)
            {
                DepthFirstSearch(heights, canReachP, 0, j);
                DepthFirstSearch(heights, canReachX, m - 1, j);
            }
            //遍历记录，如果都可到达即可加入结果
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (canReachP[i, j] && canReachX[i, j])
                    {
                        res.Add(new int[] { i, j });
                    }
                }
            }
            return res;
        }
        public void DepthFirstSearch(int[][] heights, bool[,] canReach, int i, int j)
        {
            //如果已经扫描过可达就不用扫描
            if (canReach[i, j]) return;
            //扫描过即说明可达，这也是逆流的优点
            canReach[i, j] = true;
            //上下左右深度搜索，越界就不搜索
            if (i - 1 >= 0 && heights[i - 1][j] >= heights[i][j])
            {
                DepthFirstSearch(heights, canReach, i - 1, j);
            }

            if (j - 1 >= 0 && heights[i][j - 1] >= heights[i][j])
            {
                DepthFirstSearch(heights, canReach, i, j - 1);
            }

            if (i + 1 < heights.Length && heights[i + 1][j] >= heights[i][j])
            {
                DepthFirstSearch(heights, canReach, i + 1, j);
            }

            if (j + 1 < heights[0].Length && heights[i][j + 1] >= heights[i][j])
            {
                DepthFirstSearch(heights, canReach, i, j + 1);
            }
        }
    }
}