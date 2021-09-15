using System.Collections.Generic;

namespace BinaryTreeInorderTraversal
{
    public class Solution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root is null) return new List<int>();

            var result = new List<int>();

            // 实际上不需要判空
            // 递归左
            result.AddRange(InorderTraversal(root.left));

            result.Add(root.val);

            // 递归右
            result.AddRange(InorderTraversal(root.right));

            return result;
        }
    }
}
