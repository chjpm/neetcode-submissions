/* 
Group Anagrams
Medium
Topics
Company Tags
Hints
Given an array of strings strs, group all anagrams together into sublists. You may return the output in any order.

An anagram is a string that contains the exact same characters as another string, but the order of the characters can be different.

Example 1:

Input: strs = ["act","pots","tops","cat","stop","hat"]

Output: [["hat"],["act", "cat"],["stop", "pots", "tops"]]
Example 2:

Input: strs = ["x"]

Output: [["x"]]
Example 3:

Input: strs = [""]

Output: [[""]]
Constraints:

1 <= strs.length <= 10000.
0 <= strs[i].length <= 100
strs[i] is made up of lowercase English letters.

*/
public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        // return _groupAnagrams_M1(strs); 
        // return _groupAnagrams_M2(strs); 
        return _groupAnagrams_M3(strs); 
    }

    private List<List<string>> _groupAnagrams_M1(string[] strs){
        List<List<string>> res = new List<List<string>>();

        for(int i = 0; i < strs.Length; i++)
        {
            if(res.Any(childList => childList.Contains(strs[i])))
                continue;
            HashSet<string> tempStr = new HashSet<string>();
            tempStr.Add(strs[i]);
            for(int j=i+1; j < strs.Length; j++)
            {
                if(i!=j && isAnagram(strs[i], strs[j])){
                    tempStr.Add(strs[j]);
                }
            }
            res.Add(tempStr.ToList());
        }
        return res;
    }
    private bool isAnagram(string s, string t)
    {
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
            if(count[i] != 0)
                return false;
        }
        return true;
    }

    private List<List<string>> _groupAnagrams_M2(string[] strs){
        var res = new Dictionary<string, List<string>>();
        foreach (var s in strs) {
            char[] charArray = s.ToCharArray();
            Array.Sort(charArray);
            string sortedS = new string(charArray);
            if (!res.ContainsKey(sortedS)) {
                res[sortedS] = new List<string>();
            }
            res[sortedS].Add(s);
        }
        return res.Values.ToList<List<string>>();
    }

    private List<List<string>> _groupAnagrams_M3(string[] strs){
        var res = new Dictionary<string, List<string>>();
        foreach (var s in strs) {
            int[] count = new int[26];
            foreach (char c in s) {
                count[c - 'a']++;
            }
            string key = string.Join(",", count);
            if (!res.ContainsKey(key)) {
                res[key] = new List<string>();
            }
            res[key].Add(s);
        }
        return res.Values.ToList<List<string>>();
    }
}
