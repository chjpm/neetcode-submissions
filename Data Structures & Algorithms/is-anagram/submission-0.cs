/*
Given two strings s and t, return true if the two strings are anagrams of each other, otherwise return false.

Two strings are anagrams if they contain the same characters, with each character appearing the same number of times, regardless of order.

Example 1:
Input: s = "racecar", t = "carrace"
Output: true

Example 2:
Input: s = "jar", t = "jam"
Output: false

Example 3:
Input: s = "x", t = "x"
Output: true

Constraints:
1 <= s.length, t.length <= 5 * 10^4
s and t consist of lowercase English letters.

Recommended Time & Space Complexity
You should aim for a solution with O(n + m) time and O(1) space, where n is the length of the string s and m is the length of the string t.

*/
public class Solution {
    public bool IsAnagram(string s, string t) {   
        //return _IsAnagram_M1(s, t);
        return _IsAnagram_M2(s, t);
    }

    private bool _IsAnagram_M1(string s, string t){
        if(s.Length != t.Length)
            return false;
        char[] sA = s.ToCharArray();
        char[] tA = t.ToCharArray();
        Array.Sort(sA);
        Array.Sort(tA);
        for(int i = 0; i < sA.Length; i++)
        {
           if(sA[i] != tA[i])
                return false;
        }
        return true;
    }

    private bool _IsAnagram_M2(string s, string t){
        if(s.Length != t.Length)
            return false;
        
        char[] sA = s.ToCharArray();
        char[] tA = t.ToCharArray();

        int[] count = new int[26];// count[0,0,0,...0] 26no. of 0

        for(int i = 0; i < sA.Length; i++)
        {
            count[sA[i] - 'a']++;
            count[tA[i] - 'a']--;
        }
        
        for(int i=0; i < 26; i++)
        {
            Console.WriteLine(count[i]);
            if(count[i] != 0)
                return false;
        }
        return true;
    }
}
