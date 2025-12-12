namespace Wasserstand2;
using System.Reflection.Metadata;
public class Füllstandevent(int op) : EventArgs 
{
    public int Id { get; } = op;
}
class Stadt
{
    Fluss _fluss;
    string _name;
    public Stadt(string name, Fluss fluss)
    {
        _fluss = fluss;
        _name = name;
        _fluss.Füllstand += Wasserschutz!;
    }
    public void Wasserschutz(object sender, Füllstandevent e)
    {
        Console.WriteLine(e.Id switch
        {
            4 => $"{_name} errichtet aufgrund des hohen Füllstandes des {_fluss._name} eine Wasserschutzwand",
            1 => $"Die Bewohner von {_name} sind besorgt, wegen dem niedrigen Füllstandes des {_fluss._name}",
            _ => $"Die Bewohner von {_name} genießen das Wetter"
        });
    }
}
class Damm
{
    Fluss _fluss;
    string _name;
    public Damm(string name, Fluss fluss)
    {
        _fluss = fluss;
        _name = name;
        _fluss.Füllstand += Dammverwaltung!;
    }
    public void Dammverwaltung(object sender, Füllstandevent e)
    {
        Console.WriteLine(e.Id switch
        {
            2 or 4 => $"{_name} versiegelt aufgrund des hohen Füllstandes des {_fluss._name} die Einleitungen",
            5 => $"{_name} erhöht die Wasserzuvor in den {_fluss._name}",
            _ => $"Der {_name} steht wie ein Fels in der Brandung"
        });
    }
}
class Schiff
{
    Fluss _fluss;
    string _name;
    public Schiff(string name, Fluss fluss)
    {
        _fluss = fluss;
        _name = name;
        _fluss.Füllstand += Anhalten!;

        
    }
    public void Anhalten(object sender, Füllstandevent e)
    {
        Console.WriteLine(e.Id switch
        {
            1  => $"Die {_name} bliebt aufgrund des niedrigen Füllstandes des {_fluss._name} stehen",
            2 or 4=> $"Die {_name} bliebt aufgrund des hohen Füllstandes des {_fluss._name} stehen",
            _ => $"Die {_name} befährt den {_fluss._name}"
        });
    }
}
class Fluss (string name)
{
    public event EventHandler<Füllstandevent>? Füllstand;
    public string _name {get; } = name;
    int _füllstand; 
    public void RandFullstand()
    {
        Random rng = new();
        _füllstand = rng.Next(100,10001);
        CheckFüllstand();
    }
    private void CheckFüllstand()
    {
        int eventId = _füllstand switch
        {
            < 250 => 1,
            < 3000 => 5,
            <= 8000 => 3,
            <= 8200 => 2,
            _ => 4
        };
        Füllstand!.Invoke(this, new Füllstandevent(eventId));
    }
}
class Program
{
    static void Main(string[] args)
    {
        Fluss f = new("Anduin");
        Stadt s = new("Númenor",f );
        Schiff a = new("Númerrámar", f);
        Schiff b = new("Vingilot",f);
        Damm d = new("Der große Damm von Numenor", f);
        string check;
    do
        {
            Console.Clear();
            f.RandFullstand();
            check = Console.ReadLine()!;
        } while(check != "stopp");
    }
}
