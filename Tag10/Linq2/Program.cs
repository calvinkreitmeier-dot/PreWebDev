namespace Linq2;

class Program
{
    public static void Aufgabe1()
    {
        int[] numbers = [5,4,1,3,9,8,6,7,2,0,22,12,16,18,11,19,13];
        var sum = numbers.Sum();
        var biggest = numbers.Max();
        var smallest = numbers.Min();
        var average = numbers.Average();
        var evensmallest = numbers.Where(number => number % 2 == 0).Min();
        var evenmax = numbers.Where(number=>number % 2 == 1).Max();
        var evensum = numbers.Where(number=>number % 2 == 0).Sum();
        var unevenaverage = numbers.Where(number=>number % 2 == 1).Average();
        var counteven = numbers.Where(number=>number % 2 == 0).Count();
    }
    static void Main(string[] args)
    {
        Aufgabe1();
    }
}
