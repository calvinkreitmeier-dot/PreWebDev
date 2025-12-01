using System.Text;

namespace Erweiterungsmethoden;
public static class Erweiterungsmethoden
{
    public static string Left (this string s, int count)
    {
        return s[count..];
    }
    public static string Right (this string s, int count)
    {
        return s.Substring(s.Length-count,count);
    }
    public static bool IsEvenNumber (this int n)
    {
        return n % 2 == 0;
    }
    public static bool IsPalindrome (this string s)
    {
        char[] array = s.ToLower().ToCharArray();
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
    public static string ReverseString(this string s)
    {
        char[] array = s.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
    public static string IntToBinaryString(this int n)
    {
        return Convert.ToString(n, 2);
    }
    public static string IntToHexString(this int n)
    {
        return Convert.ToString(n, 16);
    }
    public static int Power(this int n, int exponent)
    {
        return (int)Math.Pow(n, exponent);
    }
    public static int RoundUp(this double d)
    {
        return (int)Math.Ceiling(d);
    }
    public static int RoundDown(this double d)
    {
        return (int)Math.Floor(d);
    }
    public static double RoundUpAt(this double d, double roundAtThis)
    {
        if (d - Math.Floor(d) < roundAtThis)
        {
            return Math.Floor(d);
        }
        else
        {
            return Math.Ceiling(d);
        }
    }
    public static string BITLCWerbung(this string s, int absatz)
    {
        StringBuilder returner = new();
        string[] words = s.Split(' ');
        int counter = 1;
        foreach (string word in words)
        {
            returner.Append(word + " ");
            if (counter % absatz == 0)
            {
                returner.Append("BITLC Dortmund ");
            }
            counter++;
        }
        return returner.ToString();
    }
}
class Program
{
    static void Main(string[] args)
    {
    }
}
