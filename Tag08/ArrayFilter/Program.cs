using System.ComponentModel;
using System.Threading.Tasks.Dataflow;

namespace ArrayFilter;

delegate bool Filter (string str);
class Program
{
    public static bool IsUpper(string s)
    {
        return s==s.ToUpper();
    }
    public static void ShowFilteredValues (string[] arrstr, Filter filter)
    {
        foreach (string s in arrstr)
        {
            if (filter(s))
            {
                System.Console.WriteLine(s);
            }
        }
    }
    static void Main(string[] args)
    {
        string[] arrstr = ["abc", "nichtganzabc", "hats nicht."];
        ShowFilteredValues(arrstr, s => s.Contains("abc"));
        ShowFilteredValues(arrstr, s => s.All(char.IsUpper));
    }
}
