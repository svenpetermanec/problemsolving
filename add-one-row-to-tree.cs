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
    public TreeNode AddOneRow(TreeNode root, int v, int d) {
        if (root == null || d == 1) {
            return new TreeNode(v, root);
        }
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        for (var i = 1; i < d - 1; ++i) {
            var nodeCount = queue.Count;
            for (var j = 0; j < nodeCount; ++j) {
                var currentNode = queue.Dequeue();
                if (currentNode.left != null) {
                    queue.Enqueue(currentNode.left);
                }
                
                if (currentNode.right != null) {
                    queue.Enqueue(currentNode.right);
                }
            }
        }
        
        while (queue.Count > 0) {
            var currentNode = queue.Dequeue();
            var oldLeft = currentNode.left;
            currentNode.left = new TreeNode(v, oldLeft);
            
            var oldRight = currentNode.right;
            currentNode.right = new TreeNode(v, right: oldRight);
        }
        
        return root;
    }
}
