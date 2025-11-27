using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ImportantMethods
{
    internal class Regex
    {
        public static void Main(string[] args)
        {
            string email = "test@gmail.com";
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$";

            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(email, pattern);

            Console.WriteLine(isValid ? "Valid" : "Invalid");

        C: \Users\Windows 11\Documents\Learning\AMT - Training\BridgeLabz - Training - AMTPL > git rm - r--cached.vs
        fatal: pathspec '.vs' did not match any files        }
    }
}
