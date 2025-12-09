namespace LinqÜbungen;

class Program
{
    public static void Aufgabe1()
    {
        int[] numbers = [5,4,1,3,9,8,6,7,2,0,22,12,16,18,11,19,13];
        var numbersmaller7 = numbers.Where(number => number<7).Select(number => number);
        var evennumbers = numbers.Where(number=> number%2==0).Select(number => number);
        var numbersunevenunder10 = numbers.Where(number => number<10 && number%2==1);
        var fromsixthelement = numbers.Skip(5).Take(6);
        var divide3and2 = numbers.Where(number => number % 3 == 0 && number % 2 == 0).Select(number => number);
        foreach (var no in numbersmaller7){System.Console.Write(no + " ");}
        System.Console.WriteLine();
        foreach (var no in evennumbers){System.Console.Write(no + " ");}
        System.Console.WriteLine();
        foreach (var no in numbersunevenunder10){System.Console.Write(no + " ");}
        System.Console.WriteLine();
        foreach (var no in fromsixthelement){System.Console.Write(no + " ");}
        System.Console.WriteLine();
        foreach (var no in divide3and2){System.Console.Write(no + " ");}
        System.Console.WriteLine();
    }
    public static void Aufgabe2()
    {
        List<string> numbers = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen"];
        var numberlength3 = numbers.Where(number=> number.Length == 3).Select(number => number);
        var numberso = numbers.Where(number=>number.Contains("o")).Select(number=>number);
        var numbersteen = numbers.Where(number => number.EndsWith("teen")).Select(number=>number);
        var numbersTEEN = numbers.Where(number=>number.EndsWith("TEEN")).Select(number=>number);
        var numbersfour = numbers.Where(number=>number.Contains("four")).Select(number=>number);
        var numbersnofort = numbers.Where(number=>number.StartsWith("t")!=true && number.StartsWith("f")!=true);
        foreach (var no in numberlength3){System.Console.Write(no + " ");}
        System.Console.WriteLine();
        foreach (var no in numberso){System.Console.Write(no + " ");}
        System.Console.WriteLine();
        foreach (var no in numbersteen){System.Console.Write(no + " ");}
        System.Console.WriteLine();
        foreach (var no in numbersTEEN){System.Console.Write(no + " ");}
        System.Console.WriteLine();
        foreach (var no in numbersnofort){System.Console.Write(no + " ");}
        System.Console.WriteLine();
    }
    public static void Aufgabe3()
    {
        int[] numbers = [5,4,1,3,9,8,6,7,2,0,22,12,16,18,11,19,13];
        var first5 = numbers.Take(5);
        var last5 = numbers.Skip(numbers.Length-5).Take(5);
        var except3 = numbers.Skip(3).Take(numbers.Length-6);
        var till22 = numbers.TakeWhile((number, no) => number<22);
        var from12 = numbers.SkipWhile((number, no) => number !=12);
    }
    static void Main(string[] args)
    {
        Aufgabe1();
    }
}
