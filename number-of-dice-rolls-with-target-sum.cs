public class Solution {
        public int NumRollsToTarget(int n, int k, int target)
        {
            if(target == 0) return 0;
            if (target > n * k) return 0;

            int count = getRollsToDice(n,k,target);

            
            return count;
        }

        private int getRollsToDice(int n, int k, int target)
        {
            long Mod = 1000000007;
            int[][] dp = new int[n+1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[target + 1];
            }

            dp[0][0] = 1;

            for (int dice = 1; dice <= n; dice++)
            {
                for (int tar = 1; tar <= target; tar++)
                {
                    long count = 0;
                    for (int i = 1; i <= k; i++)
                    {
                        if(tar-i>=0)  count+=dp[dice-1][tar-i];
                    }
                    dp[dice][tar] = (int)(count% Mod);
                }
            }

            return dp[n][target];
        }
}
