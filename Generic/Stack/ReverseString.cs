using System;
using System.Collections.Generic;
using System.Text;

public class ReverseString
{
    public static string ReverseStringWithStack(string inputString)
    {
        Stack<char> charStack = new Stack<char>();

        foreach (char c in inputString)
        {
            charStack.Push(c);
        }

        StringBuilder reversedStringBuilder = new StringBuilder();

        while (charStack.Count > 0)
        {
            reversedStringBuilder.Append(charStack.Pop());
        }

        return reversedStringBuilder.ToString();
    }

    public static void Main(string[] args)
    {
        string original = "Hello World";
        string reversed = ReverseStringWithStack(original);
        Console.WriteLine($"Original: {original}");
        Console.WriteLine($"Reversed: {reversed}");
    }
}