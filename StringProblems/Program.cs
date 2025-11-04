using System;
namespace StringProblems
{
    internal class Program12
    {
        static void Main()
        {
            string name = "Dinessh";
            int age = 20;

            string shortName = name.Substring(0, 3);
            string trimmedName = name.Trim();
            string uppercasedName = name.ToUpper();
            string lowerCasedName = name.ToLower();


            Console.WriteLine($"My name is {name} and people call me {shortName} \n when i was in my {age}s \n and my name without start and end char {trimmedName} \n my name in uppercase : {uppercasedName} and in lower case {lowerCasedName} \n checking if my name contains letter S: {name.Contains('s')}");
        }
    }
}
