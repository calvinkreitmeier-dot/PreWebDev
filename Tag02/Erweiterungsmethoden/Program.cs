using System.Text;

namespace Erweiterungsmethoden;
public static class Erweiterungsmethoden
{
    public static string Left (this string s, int count)
    {
        StringBuilder result = new("");
        char [] chars = s.ToCharArray();
        for (int i = 0; i < count;i++)
        {
            result.Append(chars[i]);
        }
        return result.ToString();
    }
    public static string Right (this string s, int count)
    {
        StringBuilder result = new("");
        char [] chars = s.ToCharArray();
        for (int i = chars.Length-count; i < chars.Length;i++)
        {
            result.Append(chars[i]);
        }
        return result.ToString();
    }
    public static bool IsEvenNumber (this int n)
    {
        return n % 2 == 0;
    }
    public static bool IsPalindrome (this string s)
    {
        char[] array = s.ToCharArray();
        return array == array.Reverse();
    }
    public static bool ContainsDuplicateChar(this string s)
    {
        char[] chars = s.ToCharArray();
        int counter = 0;
        foreach (char c in chars)
        {
            for (int i = 1 + counter; i < chars.Length; i++)
            {
                if (c == chars[i])
                {
                    return true;
                }
            }
            counter++;
        }
        return false;
    }
    public static string RemoveDuplicateChars(this string s)
    {
        StringBuilder returner = new("");
        foreach (char c in s)
        {
            if (!returner.ToString().Contains(char.ToLower(c)) && !returner.ToString().Contains(char.ToUpper(c)))
            {
                returner.Append(c);
            }
        }
        return returner.ToString();
    }
    public static string CapitalizeFirstLetterAndLetterAfterChar(this string s, char[] c)
    {
        StringBuilder returner = new("");
        bool capitalizeNext = true;
        s = s.ToLower();
        foreach (char ch in s)
        {
            if (capitalizeNext && char.IsLetter(ch))
            {
                returner.Append(char.ToUpper(ch));
                capitalizeNext = false;
            }
            else
            {
                returner.Append(char.ToLower(ch));
            }
            if (c.Contains(ch) || ch == ' ')
            {
                capitalizeNext = true;
            }
        }
        return returner.ToString();
    }
}
class Program
{
    static void Main(string[] args)
    {
        char[] chars = { 'e', 'r', 'l' };
        Console.WriteLine($"Hello, World!".CapitalizeFirstLetterAndLetterAfterChar(chars));
    }
}
