namespace Taschenrechner;

delegate int Operation(int zahl1, int zahl2); // gleich func<int,int,int>
delegate void DisplayResult(int zahl1, int zahl2, Operation operation); // gleich Action<int,int>
class Taschenrechner
{
    public static int Multiplikation(int zahl1, int zahl2)
    {
        return zahl1*zahl2;
    }
    public static int Division(int zahl1, int zahl2)
    {
        if (zahl2 == 0){zahl2 = 1;}
        return zahl1/zahl2;
    }
    public static int Addition(int zahl1, int zahl2)
    {
        return zahl1+zahl2;
    }
    public static int Subtraktion(int zahl1, int zahl2)
    {
        return zahl1-zahl2;
    }
    public static void Ausgabe(int eins, int zwei, Operation operation)
    {
        System.Console.WriteLine($"Das Ergebnis ist: {operation(eins, zwei)}");
    }

}

class Program
{
    static void Main(string[] args)
    {
        Taschenrechner.Ausgabe(4,2,(value1, value2) => value1+value2);
        Taschenrechner.Ausgabe(4,2, (value1, value2) => value1*value2);
        Taschenrechner.Ausgabe(4,2, (value1, value2) => (int)Math.Pow(value1, value2));
    }
}
