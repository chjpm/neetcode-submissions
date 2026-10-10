/*
Question:
Given an array of integers nums and an integer target, return the indices i and j such that nums[i] + nums[j] == target and i != j.

You may assume that every input has exactly one pair of indices i and j that satisfy the condition.

Return the answer with the smaller index first.

Example 1:
Input: nums = [3,4,5,6], target = 7
Output: [0,1]
Explanation: nums[0] + nums[1] == 7, so we return [0, 1].

Example 2:
Input: nums = [4,5,6], target = 10
Output: [0,2]

Example 3:
Input: nums = [5,5], target = 10
Output: [0,1]

Constraints:
2 <= nums.length <= 1000
-10,000,000 <= nums[i] <= 10,000,000
-10,000,000 <= target <= 10,000,000
Only one valid answer exists.

*/
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
       //return twoSum_M1(nums, target); //O(n^2)
       return twoSum_M2(nums, target); //O(n)
    }
    private int[] twoSum_M1(int[] nums, int target) 
    {
         int[] res = new int[2];
        for(int i = 0; i < nums.Length; i++)
        {
            for(int j = i; j < nums.Length; j++ ){
                if(i != j && nums[i]+nums[j] == target && nums[i] != nums[j])
                {
                    res[0] = i;
                    res[1] = j;
                }
            }
        }
        return res;
    }
    private int[] twoSum_M2(int[] nums, int target){
        int[] res = new int[2];
        HashSet<int> checkDiff = new HashSet<int>();
        for(int i = 0; i < nums.Length; i++){
            int difference = target - nums[i];
            if(checkDiff.Contains(difference)){
                res[0] = checkDiff.ToList().IndexOf(difference);
                res[1] = i;
            }
            checkDiff.Add(nums[i]);
        }
        return res;
    }
}
