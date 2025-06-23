using System;
public static class StringExtensions
{
    public static bool IsPalindrome(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        string cleaned = "";

        foreach (char c in input.ToLower())
        {
            if (!char.IsWhiteSpace(c) && !char.IsPunctuation(c))
                cleaned += c;
        }

        char[] chars = cleaned.ToCharArray();
        Array.Reverse(chars);
        string reversed = new string(chars);
        
        return cleaned == reversed;
    }
}