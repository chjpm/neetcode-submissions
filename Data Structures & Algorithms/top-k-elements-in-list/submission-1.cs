public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        return topKFrequent_M1(nums, k);
    }

    private int[] topKFrequent_M1(int[] nums, int k){
        // Time Complexity = O(n log n)
        // Space Complexity = O(n)
        Dictionary<int, int> numCount = new Dictionary<int, int>();
        List<int> res = new List<int>();
        Array.Sort(nums);
        foreach(int n in nums)
        {
            if(numCount.ContainsKey(n))
            {
                numCount[n] = numCount[n] + 1;
            }
            else{
                numCount.Add(n, 1);
            }
        }
        var sortedByScoreDesc = numCount
                                    .OrderByDescending(x => x.Value)
                                    .ToDictionary(x => x.Key, x => x.Value);
        int c = 1;
        foreach(var item in sortedByScoreDesc)
        {
            if(c <= k){
               res.Add(item.Key);
               c++;
            }
        }
        return res.ToArray();
    }

}
