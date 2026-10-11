public class Solution {

    public string Encode(IList<string> strs) {
        StringBuilder res = new StringBuilder();
        foreach (string s in strs) {
            res.Append(s.Length).Append('#').Append(s);
        }
        Console.WriteLine(res.ToString());
        return res.ToString();
    }

//     public List<string> Decode(string s) { //s = "5#Hello5#World"
//         if(string.IsNullOrEmpty(s)) return new List<string>(){""};
//         List<string> strs = new List<string>();
//         for(int i = 0; i < s.Length; i++)
//         {
//             if(s[i] == '#'){
//                 strs.Add(s.Substring(i + 1, int.Parse(s[i - 1].ToString())));
//             }
//         }
//         return strs;
//    }
    public List<string> Decode(string s) {
        List<string> res = new List<string>();
        int i = 0;
        while (i < s.Length) {
            int j = i;
            while (s[j] != '#') {
                j++;
            }
            int length = int.Parse(s.Substring(i, j - i));
            i = j + 1;
            j = i + length;
            res.Add(s.Substring(i, length));
            i = j;
        }
        return res;
    }
}
