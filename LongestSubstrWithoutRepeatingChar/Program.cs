namespace LongestSubstrWithoutRepeatingChar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "abcabcbb";
            int left = 0;
            int right = 0;
            int maxLen = 0;
            while (right < s.Length)
            {
                for (int i = left; i < right; i++)
                {
                    if (s[i] == s[right])
                    {
                        left = i + 1;
                        break;
                    }

                }
                if(maxLen < right - left + 1)
                {
                    maxLen = right - left + 1;
                }
                    right++;

            }
            Console.Write(maxLen);
        }
    }
}
