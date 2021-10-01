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
    public TreeNode PruneTree(TreeNode root) {
        if (root == null || root.val == 0 && !DoesSubtreeContainOne(root)) {
            return null;
        }
        
        if (root.left?.val == 0 && !DoesSubtreeContainOne(root.left)) {
            root.left = null;
        }
        
        if (root.right?.val == 0 && !DoesSubtreeContainOne(root.right)) {
            root.right = null;
        }
        
        PruneTree(root.left);
        PruneTree(root.right);
        return root;
    }
    
    public bool DoesSubtreeContainOne(TreeNode root) {
        if (root == null) {
            return false;
        }
        
        return DoesSubtreeContainOne(root.left) || DoesSubtreeContainOne(root.right) || root.val == 1;
    }
}