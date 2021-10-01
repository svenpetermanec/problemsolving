/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if (root == null) {
            return result;
        }
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0) {
            var size = queue.Count;
            var currentList = new List<int>();
            for (var i = 0; i < size; ++i) {
                if (queue.Peek().left != null) {
                    queue.Enqueue(queue.Peek().left);
                }
                
                if (queue.Peek().right != null) {
                    queue.Enqueue(queue.Peek().right);
                }
                
                currentList.Add(queue.Dequeue().val);
            }
            
            result.Add(currentList);
        }
        
        return result;
    }
}