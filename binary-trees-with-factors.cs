public class Solution {
    
    private static readonly long Mod = (long) (1e9 + 7);
    
    public int NumFactoredBinaryTrees(int[] arr) {
        Array.Sort(arr);
        
        var dp = new Dictionary<int, long>(); // Number->possible ways to make that number
        foreach (var num in arr) {
            dp[num] = 1; // Base
        }
        
        long result = 0L;
        foreach (var dividend in arr) {
            foreach (var divisor in arr) {
                if (dividend <= divisor) {
                    break;
                }
                
                if (dividend % divisor == 0) {
                    dp[dividend] += (dp[divisor] * dp.GetValueOrDefault(dividend / divisor)) % Mod;
                }
            }
            
            result = (result + dp[dividend]) % Mod;
        }
        
        return (int) result;
    }
}

public static class IDictionaryExtensions {
    public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default) {
        return dict.TryGetValue(key, out var value) ? value : defaultValue;
    }
}