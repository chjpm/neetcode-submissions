public class Solution {
    public bool hasDuplicate(int[] nums) {
        /* Solution 1: Basic approch
        Complexity
Time: O(n²) because every pair may be compared
Space: O(1)
For nums.Length = 100,000, this could require billions of comparisons.

Better approach: HashSet
A HashSet<int> stores values we have already seen. Before adding each number, check whether it is already present.

        for(int i=0; i < nums.Length; i++)
        {
            for(int j=i+1; j < nums.Length; j++)
            {
                if(nums[i] == nums[j])
                {
                    return true;
                }
            }
        }
        return false; 
        */

        /* Solution 2: Array sort approch
        For nums = [1, 2, 3, 3]:
        1 {} No {1} 2 {1} No {1, 2} 3 {1, 2} No {1, 2, 3} 3 {1, 2, 3} Yes Return true
        
        Complexity:
        Time: O(n log n)
        Space: Depends on the sorting implementation
        Note: This modifies the input array
        For this problem, use the HashSet approach unless modifying the array or avoiding 
        extra memory is important.

        
        Array.Sort(nums);
        for(int i = 1; i < nums.Length; i++)
        {
            if(nums[i-1] == nums[i])
                return true;
        }
        return false;
        */

        /* Solution 3: 
        For nums = [1, 2, 3, 3]:

        1 {} No {1} 2 {1} No {1, 2} 3 {1, 2} No {1, 2, 3} 3 {1, 2, 3} Yes Return true
        Complexity
        Time: O(n) average
        Space: O(n)
        This is generally the preferred solution because it is much faster than comparing every
        pair.
        */
        HashSet<int> seen = new HashSet<int>();

        foreach(int num in nums)
        {
            if(seen.Contains(num))
                return true;
            seen.Add(num);
        }
        return false;
    }
}