using System.Runtime.InteropServices;

namespace Tag01;

class Program
{
    static int CountCharInString(string s, char c)
    {
        int count = 0;
        s = s.ToLower();
        foreach (char ch in s)
        {
            if (ch == c)
            {
                count++;
            }
        }
        return count;
    }
    static int CountCharInStringCaseSensitive(string s, char c)
    {
        int count = 0;
        foreach (char ch in s)
        {
            if (ch == c)
            {
                count++;
            }
        }
        return count;
    }
    static void AnalyseString(string s)
    {
        int vokalCount = 0;
        int consonantCount = 0;
        int umlautCount = 0;
        int zahlenCount = 0;
        int sonstigeCount = 0;
        s = s.ToLower();
        foreach (char c in s)
        switch (c)
        {
            case 'a' or 'e' or 'i' or 'o' or 'u':
                vokalCount++;
                break;
            case  'b' or  'c' or 'd' or 'f' or 'g' or 'h' or 'j' or 'k' or 'l' or 'm' or 'n' or 'p' or 'q' or 'r' or 's' or 'ß' or 't' or  'v' or 'w' or 'x' or 'z':
                consonantCount++;
                break;
            case 'ä' or 'ö' or 'ü':
                umlautCount++;
                break;
            case char f when char.IsDigit(f):
                zahlenCount++;
                break;
            default:
                sonstigeCount++;
                break;

        }
        System.Console.WriteLine($"Vokale: {vokalCount}, Konsonanten: {consonantCount}, Umlaute: {umlautCount}, Zahlen: {zahlenCount}, Sonstige: {sonstigeCount}");
    }
    static void PalindromeCheck(string s)
    {
        string reversed = "";
        for (int i = s.Length - 1; i >= 0; i--)
        {
            reversed += s[i];
        }
        if (s == reversed)
        {
            System.Console.WriteLine($"{s} ist ein Palindrom.");
        }
        else
        {
            System.Console.WriteLine($"{s} ist kein Palindrom.");
        }
    }
    static void PalindromeCheckNoSpaces(string s)
    {
        string cleaned = s.Replace(" ", "").ToLower();
        string reversed = "";
        for (int i = cleaned.Length - 1; i >= 0; i--)
        {
            reversed += cleaned[i];
        }
        if (cleaned == reversed)
        {
            System.Console.WriteLine($"{s} ist ein Palindrom.");
        }
        else
        {
            System.Console.WriteLine($"{s} ist kein Palindrom.");
        }
    }
    static bool ContainsDuplicateChar(string s)
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
    static string RemoveDuplicateChars(string s)
    {
        string returner = "";
        foreach (char c in s)
        {
            if (!returner.Contains(char.ToLower(c)) && !returner.Contains(char.ToUpper(c)))
            {
                returner += c;
            }
        }
        return returner;
    }
    static string CapitalizeFirstLetter(string s)
    {
        string[] words = s.Split(' ');
        string returner = "";
        foreach (string word in words)
        {
            if (word.Length > 0)
            {
                string capitalizedWord = char.ToUpper(word[0]) + word[1..];
                returner += capitalizedWord + " ";
            }
        }
        return returner.TrimEnd();
    }
    static string CapitalizeFirstLetterAndLetterAfterChar(string s, char[] c)
    {
        string returner = "";
        bool capitalizeNext = true;
        s = s.ToLower();
        foreach (char ch in s)
        {
            if (capitalizeNext && char.IsLetter(ch))
            {
                returner += char.ToUpper(ch);
                capitalizeNext = false;
            }
            else
            {
                returner += ch;
            }
            if (c.Contains(ch) || ch == ' ')
            {
                capitalizeNext = true;
            }
        }
        return returner;
    }
    static void Main(string[] args)
    {
        
    }
}
