namespace Tag01;

class Program
{
    static int CountCharInString(string s, char c)
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
    static int CountCharInStringCaseSensitive(string s, char c)
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
    void AnalyseString(string s)
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
            case '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9':
                zahlenCount++;
                break;
            default:
                sonstigeCount++;
                break;
        }
        System.Console.WriteLine($"Vokale: {vokalCount}, Konsonanten: {consonantCount}, Umlaute: {umlautCount}, Zahlen: {zahlenCount}, Sonstige: {sonstigeCount}");
    }
    static void Main(string[] args)
    {

    }
}
