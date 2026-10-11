public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        return topKFrequent_M4(nums, k);
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

    private int[] topKFrequent_M2(int[] nums, int k) {
        /*
        Time complexity: O(nlogn)
        Space complexity: O(n)
        */
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (count.ContainsKey(num)) count[num]++;
            else count[num] = 1;
        }

        List<int[]> arr = count.Select(entry => new int[] {entry.Value, entry.Key}).ToList();
        arr.Sort((a, b) => b[0].CompareTo(a[0]));

        int[] res = new int[k];
        for (int i = 0; i < k; i++) {
            res[i] = arr[i][1];
        }
        return res;
    }

    //Min-Heap
    private int[] topKFrequent_M3(int[] nums, int k) {
        /*
        Time complexity: O(n)
        Space complexity: O(n)
        */
        var count = new Dictionary<int, int>();
        foreach (var num in nums) {
            if (count.ContainsKey(num)) {
                count[num]++;
            } else {
                count[num] = 1;
            }
        }

        var heap = new PriorityQueue<int, int>();
        foreach (var entry in count) {
            heap.Enqueue(entry.Key, entry.Value);
            if (heap.Count > k) {
                heap.Dequeue();
            }
        }

        var res = new int[k];
        for (int i = 0; i < k; i++) {
            res[i] = heap.Dequeue();
        }
        return res;
    }

    //Bucket Sort
    public int[] topKFrequent_M4(int[] nums, int k) {
        /*
        Time complexity: O(n)
        Space complexity: O(n)
        */
        Dictionary<int, int> count = new Dictionary<int, int>();
        List<int>[] freq = new List<int>[nums.Length + 1];
        for (int i = 0; i < freq.Length; i++) {
            freq[i] = new List<int>();
        }

        foreach (int n in nums) {
            if (count.ContainsKey(n)) {
                count[n]++;
            } else {
                count[n] = 1;
            }
        }
        foreach (var entry in count){
            freq[entry.Value].Add(entry.Key);
        }

        int[] res = new int[k];
        int index = 0;
        for (int i = freq.Length - 1; i > 0 && index < k; i--) {
            foreach (int n in freq[i]) {
                res[index++] = n;
                if (index == k) {
                    return res;
                }
            }
        }
        return res;
    }
}
