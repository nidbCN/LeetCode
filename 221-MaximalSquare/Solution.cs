namespace MaximalSquare
{
    public class Solution
    {
        public int MaximalSquare(char[][] matrix)
        {
            var maxSide = 0;

            // 判空
            if (matrix is null || matrix.Length == 0 || matrix[0].Length == 0)
                return 0;

            var rows = matrix.Length;
            var columns = matrix[0].Length;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        // 遇到一个 1 作为正方形的左上角
                        maxSide = maxSide > 1 ? maxSide : 1;

                        // 计算可能的最大正方形边长
                        int currentMaxSide = rows - i > columns - j ? columns - j : rows - i;
                        for (var k = 1; k < currentMaxSide; k++)
                        {
                            // 判断新增的一行一列是否均为 1
                            var flag = true;

                            if (matrix[i + k][j + k] == '0')
                                break;

                            for (var m = 0; m < k; m++)
                            {
                                if (matrix[i + k][j + m] == '0' || matrix[i + m][j + k] == '0')
                                {
                                    flag = false;
                                    break;
                                }
                            }

                            if (flag)
                            {
                                maxSide = maxSide > k + 1 ? maxSide : k + 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return maxSide * maxSide;
        }
    }
}
