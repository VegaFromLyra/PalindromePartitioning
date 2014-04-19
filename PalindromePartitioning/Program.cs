using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// abaa
// So for a given string s of length n, start with index 1 and try to make cuts
// at all possible locations
// So for example - a + baa
// ab + aa 
// aba + a
// And each stage keep track of how many cuts are needed
// The minimum of these 3 will be your answer
namespace PalindromePartitioning
{
    class Program
    {
        static void Main(string[] args)
        {
            // string input = "abaa";
            // string input = "ababbbabbababa";
            string input = "pqrstu";

            int minimumNumberOfCuts = PartitionPalindrome(input);

            Console.WriteLine("Minimum number of cuts is {0}", minimumNumberOfCuts);
        }

        static Dictionary<string, int> cache = new Dictionary<string, int>();

        static int PartitionPalindrome(string input)
        {
            if (IsPalindrome(input))
            {
                return 0;
            }

            if (cache.ContainsKey(input))
            {
                return cache[input];
            }

            List<int> cuts = new List<int>();
            for (int i = 1; i <= input.Length - 1; i++)
            {
                int numberOfCuts = 0;
                numberOfCuts = 1 + PartitionPalindrome(input.Substring(0, i)) + PartitionPalindrome(input.Substring(i));
                cuts.Add(numberOfCuts);
            }

            cache.Add(input, cuts.Min());

            return cuts.Min();
        }

        static bool IsPalindrome(string s)
        {
            int start = 0;
            int end = s.Length - 1;

            while (start < end)
            {
                if (s[start] == s[end])
                {
                    start++;
                    end--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
