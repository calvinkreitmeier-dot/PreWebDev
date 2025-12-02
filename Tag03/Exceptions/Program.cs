using System.Globalization;
using System.Text;

namespace Exceptions;
static class Eingabe
{
public static int IntEingabe()
{
    System.Console.Write("Bitte eine Zahl eingeben:");
    string number = Console.ReadLine()!;
    if (string.IsNullOrEmpty(number))
    {
    throw new ArgumentException("Die Eingabe muss einen Wert haben: ");
    }
    if (!int.TryParse(number, out _))
    {
        throw new FormatException("Die Eingabe muss eine Zahl sein: ");
    }
    return Convert.ToInt32(number);
}
public static int IntEingabe(int min, int max)
{
    System.Console.Write("Bitte eine Zahl eingeben: ");
    string number = Console.ReadLine()!;
    if (string.IsNullOrEmpty(number))
    {
    throw new ArgumentException("Die Eingabe muss einen Wert haben: ");
    }
    if (!int.TryParse(number, out _))
    {
        throw new FormatException("Die Eingabe muss eine Zahl sein: ");
    }
    if (Convert.ToInt32(number) < min || Convert.ToInt32(number) > max)
    {
        throw new ArgumentOutOfRangeException($"Die Eingabe muss zwischen {min} und {max} liegen: ");
    }
    return Convert.ToInt32(number);
}
public static double DoubleEingabe()
{
    System.Console.Write("Bitte eine Zahl eingeben:");
    string number = Console.ReadLine()!;
    if (string.IsNullOrEmpty(number))
    {
    throw new ArgumentException("Die Eingabe muss einen Wert haben: ");
    }
    if (!double.TryParse(number, out _))
    {
        throw new FormatException("Die Eingabe muss eine Zahl sein: ");
    }
    return Convert.ToDouble(number);
}
public static double DoubleEingabe(int min, int max)
{
    System.Console.Write("Bitte eine Zahl eingeben: ");
    string number = Console.ReadLine()!;
    if (string.IsNullOrEmpty(number))
    {
    throw new ArgumentException("Die Eingabe muss einen Wert haben: ");
    }
    if (!double.TryParse(number, out _))
    {
        throw new FormatException("Die Eingabe muss eine Zahl sein: ");
    }
    if (Convert.ToDouble(number) < min || Convert.ToDouble(number) > max)
    {
        throw new ArgumentOutOfRangeException($"Die Eingabe muss zwischen {min} und {max} liegen: ");
    }
    return Convert.ToDouble(number);
}
public static float FloatEingabe()
{
    System.Console.Write("Bitte eine Zahl eingeben:");
    string number = Console.ReadLine()!;
    if (string.IsNullOrEmpty(number))
    {
    throw new ArgumentException("Die Eingabe muss einen Wert haben: ");
    }
    if (!float.TryParse(number, out _))
    {
        throw new FormatException("Die Eingabe muss eine Zahl sein: ");
    }
    return Convert.ToSingle(number);
}
public static float FloatEingabe(int min, int max)
{
    System.Console.Write("Bitte eine Zahl eingeben: ");
    string number = Console.ReadLine()!;
    if (string.IsNullOrEmpty(number))
    {
    throw new ArgumentException("Die Eingabe muss einen Wert haben: ");
    }
    if (!float.TryParse(number, out _))
    {
        throw new FormatException("Die Eingabe muss eine Zahl sein: ");
    }
    if (Convert.ToSingle(number) < min || Convert.ToSingle(number) > max)
    {
        throw new ArgumentOutOfRangeException($"Die Eingabe muss zwischen {min} und {max} liegen: ");
    }
    return Convert.ToSingle(number);
}
}
class Program
{
public static int Divide(string divided, string divisor)
{
    if (divided == null || divisor == null)        {
        throw new ArgumentException("Beide Argumente müssen einen Wert haben.");
    }
    if (divisor == "0")
    {
        throw new ArithmeticException("Der Divisor darf nicht 0 sein.");
    }
    if (!int.TryParse(divided, out _) || !int.TryParse(divisor, out _))
    {
        throw new FormatException("Beide Argumente müssen Zahlen sein.");
    }
    return Convert.ToInt32(divided) / Convert.ToInt32(divisor);
}
public static string ISBNCheck()
    {
        System.Console.WriteLine("Bitte eine ISBN-13 eingeben:");
        string isbn = Console.ReadLine()!;
        StringBuilder returner = new();
        if (string.IsNullOrEmpty(isbn))
        {
            throw new ArgumentException("Die Eingabe muss einen Wert haben.");
        }
        if (isbn.Length != 13)
        {
            throw new ArgumentOutOfRangeException("Die ISBN muss 13 Zeichen lang sein.");
        }
        if (!Int64.TryParse(isbn, out _))
        {
            throw new FormatException("Die ISBN darf nur aus Zahlen bestehen.");
        }
        for (int i = 0; i < isbn.Length; i++)
        {
        returner.Append(i switch
        {
            4 => $"-{i}-",
            9 => $"-{i}",
            13 => $"-{i}",
            _ => isbn[i].ToString()
        });
    }
    return returner.ToString();
}

    static void Main(string[] args)
    {
        System.Console.WriteLine(ISBNCheck());
        
    }
}

