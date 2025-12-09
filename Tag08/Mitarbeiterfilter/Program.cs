using System.Runtime.InteropServices;

namespace Mitarbeiterfilter;
delegate bool MitarbeiterFilter (Mitarbeiter ma);
delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
class Mitarbeiter(string name, int alter, double gehalt)
{

public string _name {get ;} = name;
public int _alter {get ;} = alter;
public double _gehalt {get ;} = gehalt;
public string MitarbeiterAusgeben()
    {
        return $"Name: {_name} Alter: {_alter} Gehalt: {_gehalt}";
    }
public static void FilterMitarbeiter (List<Mitarbeiter> ml, MitarbeiterFilter mf)
    {
        foreach (Mitarbeiter mab in ml)
        {
            if (mf(mab))
            {
                System.Console.WriteLine(mab.MitarbeiterAusgeben());
            }
        }
    }
public static void GenericAgeFilterMitarbeiter (List<Mitarbeiter> ml,int alter)
    {
        Func<int, Mitarbeiter, bool> _mitarbeiterAlter = (alter,mitarbeiter) => mitarbeiter._alter > alter;
        foreach (Mitarbeiter mab in ml)
        {
            if (_mitarbeiterAlter(alter,mab))
            {
                System.Console.WriteLine(mab.MitarbeiterAusgeben());
            }
        }
    }
public static void GenericEarningsFilterMitarbeiter (List<Mitarbeiter> ml, double gehalt)
    {
        Func<double, Mitarbeiter, bool> _mitarbeiterGehalt = (gehalt,mitarbeiter) => mitarbeiter._gehalt > gehalt;
        foreach (Mitarbeiter mab in ml)
        {
            if (_mitarbeiterGehalt(gehalt,mab))
            {
                System.Console.WriteLine(mab.MitarbeiterAusgeben());
            }
        }
    }
public static void GenericNameFilterMitarbeiter (List<Mitarbeiter> ml, string name)
    {
        Func<string,Mitarbeiter,bool> _mitarbeiterName = (name, mitarbeiter) => mitarbeiter._name.Contains(name);
        foreach (Mitarbeiter mab in ml)
        {
            if (_mitarbeiterName(name, mab))
            {
                System.Console.WriteLine(mab.MitarbeiterAusgeben());
            }
        }
    }
public static void SortiereMitarbeiter(List<Mitarbeiter> ml, Comparison<Mitarbeiter> vergleich)
    {
        ml.Sort(vergleich);
        foreach (Mitarbeiter mab in ml)
        {
            System.Console.WriteLine(mab.MitarbeiterAusgeben());
        }
    }
    

}

class Program
{
    static void Main(string[] args)
    {
        
        List<Mitarbeiter> listeMitarbeiter = [];
        for (int i = 8; i > 0;i-- )
        {
            listeMitarbeiter.Add(new Mitarbeiter($"Mitarbeiter{i}", 20+i, 1000*i));
        }
        Mitarbeiter.GenericAgeFilterMitarbeiter(listeMitarbeiter, 23);
        // Mitarbeiter.FilterMitarbeiter(listeMitarbeiter, m => m._alter > 23);
        // System.Console.WriteLine("---------------");
        // Mitarbeiter.SortiereMitarbeiter(listeMitarbeiter, (m1, m2) => m1._alter.CompareTo(m2._alter));
    }
}
